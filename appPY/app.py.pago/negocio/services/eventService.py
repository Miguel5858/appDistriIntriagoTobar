import pika
import json
from negocio.dtos.pagoDto import PagoDto

class RabbitMQPublisher:
    def __init__(self, host='localhost', port=5672, user='admin', password='admin'):
        self.host = host
        self.port = port
        self.credentials = pika.PlainCredentials(user, password)

    def publish_message(self, pago: PagoDto):
        # Configurar la conexión a RabbitMQ en el contenedor Docker
        connection = pika.BlockingConnection(pika.ConnectionParameters(
            self.host,  # RabbitMQ host
            self.port,  # RabbitMQ port
            '/',        # Virtual host por defecto
            self.credentials  # Credenciales que configuraste
        ))

        channel = connection.channel()
        nombre_cola = 'pagoDeposito'

        # Declara la cola
        channel.queue_declare(queue=nombre_cola)

        # Convierte la lista de objetos a JSON
        #mensaje = json.dumps([pagos.to_dict() for pago in pagos])
        #Convierte un objeto a JSON
        mensaje = json.dumps(pago.__dict__)

        # Publica el mensaje
        channel.basic_publish(exchange='',routing_key=nombre_cola, body=mensaje)
        print("Mensaje enviado a la cola")
        connection.close()
