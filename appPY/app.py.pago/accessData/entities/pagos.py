from sqlalchemy.ext.declarative import declarative_base
Base = declarative_base()
from sqlalchemy import Column, Integer, String, Float

class Pago(Base):

    __tablename__ = "pagos"

    id = Column(Integer, primary_key=True, index=True, autoincrement=True)
    nombre =  Column(String(50))
    cuenta =  Column(String(50))
    tipo = Column(String(10))
    fecha = Column(String(10))
    cantidad = Column(Float)

