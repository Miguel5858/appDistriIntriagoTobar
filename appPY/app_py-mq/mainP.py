import pika
import json
from negocio.DTOs.models import Producto

def publish_message(productos):
    # connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    # Configurar la conexión a RabbitMQ en el contenedor Docker
    connection = pika.BlockingConnection(pika.ConnectionParameters(
        'localhost',  # RabbitMQ está mapeado en localhost a través del puerto 5672
        5672,         # Puerto expuesto en Docker Compose
        '/',          # Virtual host por defecto
        pika.PlainCredentials('admin', 'admin')  # Credenciales que configuraste
    ))

    channel = connection.channel()
    
    nombreCola = 'cuentasMasivas'

    # Declara la cola
    channel.queue_declare(queue=nombreCola)

    # Convierte la lista de objetos a JSON
    mensaje = json.dumps([producto.to_dict() for producto in productos])

    # Publica el mensaje
    channel.basic_publish(exchange='',
                          routing_key=nombreCola,
                          body=mensaje)
    print("Mensaje enviado a la cola")
    connection.close()


if __name__ == "__main__":
    
    productos = [
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote4", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote5", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote6", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote7", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote8", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote9", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote10", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote12", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote13", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote14", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote15", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote16", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(1, "Lote1", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(2, "Lote2", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29"),
        Producto(3, "Lote3", "lote numero 1 escuela San Diego empresa pymes", "2024-08-29")
    ]
    publish_message(productos)
    