class Producto:
    def __init__(self, id, lote, descripcion, fecha):
        self.id = id
        self.lote = lote
        self.descripcion = descripcion
        self.fecha = fecha

    def to_dict(self):
        return {
            'Id': self.id,
            'lote': self.lote,
            'Descripcion': self.descripcion,
            'Fecha': self.fecha,
        }
