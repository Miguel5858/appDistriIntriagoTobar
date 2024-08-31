import pika
import json

from negocio.DTOs.models import Producto

productosList = []


def callbackGeneric(ch, method, properties, body):
    try:
        # Convertir el mensaje JSON en un objeto Python (puede ser una lista o diccionario)
        data = json.loads(body)

        # Verificar si es una lista de diccionarios
        if isinstance(data, list):
            for index, item in enumerate(data):
                print(f"Item {index + 1}:")
                if isinstance(item, dict):
                    for key, value in item.items():
                        print(f"  {key}: {value}")
                else:
                    print(f"  Valor: {item}")
        elif isinstance(data, dict):
            print("Objeto JSON recibido:")
            for key, value in data.items():
                print(f"  {key}: {value}")
        else:
            print("Mensaje no es un diccionario ni una lista de diccionarios.")
            print(f"Contenido: {data}")
    except json.JSONDecodeError:
        print("Error al decodificar el mensaje JSON")
    
    # Confirmar la recepción del mensaje
    ch.basic_ack(delivery_tag=method.delivery_tag)
    
    

def callback(ch, method, properties, body):
    productos = json.loads(body)
    print(productos)
    
    """
    for producto in productos:
        print(f"ID: {producto['id']}, Lote: {producto['lote']}, Descripción: {producto['descripcion']}, Fecha: {producto['fecha']}")
    """
    # Convertir cada diccionario en un objeto Producto y agregarlo a la lista
    for item in productos:
        producto = Producto(
            id=item['id'],
            lote=item['lote'],
            descripcion=item['descripcion'],
            fecha=item['fecha']
        )
        productosList.append(producto)
        
    ch.basic_ack(delivery_tag=method.delivery_tag)
        
    print("Mensaje recibido y convertido a objetos Producto:")
    for producto in productos:
        print(vars(producto['success']))



def consume_message():
    #connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    connection = pika.BlockingConnection(pika.ConnectionParameters(
        'localhost',  # RabbitMQ está mapeado en localhost a través del puerto 5672
        5672,         # Puerto expuesto en Docker Compose
        '/',          # Virtual host por defecto
        pika.PlainCredentials('admin', 'admin')  # Credenciales que configuraste
    ))
    channel = connection.channel()
    
    nombreCola = 'TransactionClientCreateEvent'

    # Declara la cola
    channel.queue_declare(queue=nombreCola)

    # Consume los mensajes
    channel.basic_consume(queue=nombreCola, on_message_callback=callbackGeneric, auto_ack=False)

    print("Esperando mensajes...")
    channel.start_consuming()

if __name__ == "__main__":
    consume_message()
