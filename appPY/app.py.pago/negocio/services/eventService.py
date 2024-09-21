import pika
import json
from negocio.dtos.pagoDto import PagoDto

class RabbitMQPublisher:
    
    def __init__(self, host='localhost', port=5672, user='admin', password='admin'):
        self.host = host
        self.port = port
        self.credentials = pika.PlainCredentials(user, password)
        self.connection_params = pika.ConnectionParameters(
            self.host,
            self.port,
            '/',
            self.credentials
        )

    def _connect(self):
        return pika.BlockingConnection(self.connection_params)

    def publish_message(self, pago: PagoDto):
        connection = self._connect()
        channel = connection.channel()
        nombre_cola = 'pagoDeposito'

        channel.queue_declare(queue=nombre_cola)
        mensaje = json.dumps(pago.__dict__)
        channel.basic_publish(exchange='', routing_key=nombre_cola, body=mensaje)
        print("Mensaje enviado a la cola")
        connection.close()

    def consume_messages(self, mensajes_recibidos, nombre_cola='saleQueue'):
        connection = self._connect()
        channel = connection.channel()

        channel.queue_declare(queue=nombre_cola)

        def callback(ch, method, properties, body):
            mensaje = json.loads(body)
            print(f"Mensaje recibido: {mensaje}")
            
            #Agregar el mensaje a la lista compartida
            mensajes_recibidos.append(mensaje)

        channel.basic_consume(queue=nombre_cola, on_message_callback=callback, auto_ack=True)
        print('Esperando mensajes...')
        channel.start_consuming()
