from threading import Thread
import time
from fastapi import FastAPI
from fastapi.responses import HTMLResponse, JSONResponse
from fastapi.encoders import jsonable_encoder
from negocio.dtos.pagoDto import PagoDto
from negocio.services.pagoService import PagoService
from contextlib import asynccontextmanager

app = FastAPI()
app.title = "API servicios pagos"
app.version = "0.0.1"

pagoServicio = PagoService()
mensajes_recibidos = []


@app.get('/', tags=['pagos'])
def message():
    return HTMLResponse('<h1>Aplicaciones distribuidas -- APIs Python</h1>')

@app.post('/pago', tags=['pagos'], response_model=dict, status_code=201)
def depositar(pago: PagoDto) -> dict:
        pagoRegistrado = pagoServicio.RealizarPago(pago)
        return JSONResponse(content=jsonable_encoder(pagoRegistrado))


@app.get('/pagos/', tags=['pagos'], response_model=dict)
def ObtenerPagos() -> dict:
    pagoList = pagoServicio.ConsultarPago()
    if not pagoList:
        return JSONResponse(status_code=404, content={'message':'No existen para la pagos realizados'})
    return JSONResponse(content=jsonable_encoder(pagoList))


def start_rabbitmq_listener():
    def consume():
        pagoServicio.publisher.consume_messages(mensajes_recibidos)
        
    thread = Thread(target=consume)
    thread.start()

@asynccontextmanager
async def lifespan(app: FastAPI):
    # Código de inicio
    start_rabbitmq_listener()
    yield
    # Código de cierre (si es necesario)

app.router.lifespan_context = lifespan

def guardar_en_base_de_datos():
    # Aquí puedes implementar la lógica para guardar los mensajes en la base de datos
    while True:
        if mensajes_recibidos:
            mensaje = mensajes_recibidos.pop(0)
            print(f"Guardando mensaje en la base de datos: {mensaje}")
            # Lógica para guardar en la base de datos
        time.sleep(1)  # Ajusta el tiempo de espera según sea necesario


# Iniciar el proceso de guardado en la base de datos en un hilo separado
Thread(target=guardar_en_base_de_datos).start()