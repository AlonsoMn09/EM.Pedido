using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Request.Pedido
{
    public class CreatePedidoRequest
    {
        public int IdCliente { get; set; }
        public decimal Adelanto { get; set; }
        public List<CreatePedidoDetalleRequest> PedidoDetalles { get; set; } = new();
    }

    public class CreatePedidoDetalleRequest {
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
