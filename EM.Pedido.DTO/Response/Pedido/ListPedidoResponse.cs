using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Response.Pedido
{
    public class ListPedidoResponse
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; } = default!;
        public string NumeroDocumento { get; set; } = default!;
        public decimal TotalBruto { get; set; }
        public decimal TotalNeto { get; set; }
        public decimal Total { get; set; }
        public decimal Adelanto { get; set; }
        public int CantidadProductos { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
