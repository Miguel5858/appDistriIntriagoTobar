from typing import Optional
from pydantic import BaseModel, Field

"""clase para obtener y registrar un deposito por el API"""
class PagoDto(BaseModel):
        id: Optional[int] = None
        nombre:str = Field(min_length=5, max_length=50)
        cuenta:str = Field(min_length=5, max_length=50)
        tipo:str = Field(min_length=5, max_length=10)
        cantidad:float = Field(ge=1, le=1000000)


"""clase para validar las credenciales del token"""
class UsuarioDto(BaseModel):
    email:str
    password:str