using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EM.Pedido.DTO.Response.Pedido
{
    public class ListPedidoResponse
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        [Display(Name="Razón social")]
        public string RazonSocial { get; set; } = default!;
        [Display(Name = "Número de documento")]
        public string NumeroDocumento { get; set; } = default!;
        [Display(Name = "Total Bruto")]
        public decimal TotalBruto { get; set; }
        [Display(Name = "Total Neto")]
        public decimal TotalNeto { get; set; }
        [Display]
        public decimal Total { get; set; }
        [Display]
        public decimal Adelanto { get; set; }
        public int CantidadProductos { get; set; }
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
    }
}
