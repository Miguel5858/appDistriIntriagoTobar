from fastapi import FastAPI
from fastapi.responses import HTMLResponse, JSONResponse
from fastapi.encoders import jsonable_encoder
from negocio.dtos.pagoDto import PagoDto
from negocio.services.pagoService import PagoService

app = FastAPI()
app.title = "API servicios pagos"
app.version = "0.0.1"

pagoServicio = PagoService()

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
        