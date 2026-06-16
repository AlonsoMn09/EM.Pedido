using EM.Pedido.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EM.Pedido.DTO.Request.Pedido
{
    public class CreatePedidoRequest
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = default!;
        public string NumeroDocumento { get; set; } = default!;
        public decimal Adelanto { get; set; }
        public List<CreatePedidoDetalleRequest> PedidoDetalles { get; set; } = new();
    }

    public class CreatePedidoDetalleRequest {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public string Marca { get; set; } = default!;
        public int Stock { get; set; } = default!;

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un número positivo")]
        public decimal Cantidad { get; set; } = 1;
        public decimal PrecioUnitario { get; set; }
        public decimal Total => PrecioUnitario * Cantidad;
    }
}
