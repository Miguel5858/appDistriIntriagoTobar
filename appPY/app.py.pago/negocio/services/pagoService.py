from datetime import datetime
from threading import Thread
from accessData.conexion import Database, DATABASE_URL
from accessData.entities.pagos import Base, Pago
from negocio.dtos.pagoDto import PagoDto
from negocio.services.eventService import RabbitMQPublisher
from negocio.services.genericService import GenericService

class PagoService:
    
    def __init__(self):
        self.db = Database(DATABASE_URL)
        self.engine =  self.db.engine
        # Crea todas las tablas definidas en el entities
        Base.metadata.create_all(bind= self.engine)
        self.pagoService = GenericService[Pago](Pago, self.db)
        self.publisher = RabbitMQPublisher()
        self.mensajes_recibidos = []
    
    def RealizarPago(self, pagoDto: PagoDto):
        # Obtener la fecha actual
        fecha_actual = datetime.now()
        # Formatear la fecha en formato dd/mm/YYYY
        fecha_formateada = fecha_actual.strftime("%d/%m/%Y")
        
        pagoRealizado = self.pagoService.create(nombre=pagoDto.nombre, cuenta=pagoDto.cuenta, tipo=pagoDto.tipo,
                                                cantidad=pagoDto.cantidad, fecha=fecha_formateada)
        
        # Convertir el pago realizado en un PagoDto
        pagoDtoRealizadoDTO = PagoDto(
            id=pagoRealizado.id,
            nombre=pagoRealizado.nombre,
            tipo=pagoRealizado.tipo,
            cuenta=pagoRealizado.cuenta,
            cantidad=pagoRealizado.cantidad
        )
        
    
        self.publisher.publish_message(pagoDtoRealizadoDTO)
        
        return pagoDtoRealizadoDTO
        

    def ConsultarPago(self):
        listaPagos = self.pagoService.getAll()
        return listaPagos
    
    def GuardarFactura(self):
        pass