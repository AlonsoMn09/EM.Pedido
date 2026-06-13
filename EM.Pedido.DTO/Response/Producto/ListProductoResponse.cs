using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Response.Producto
{
    public class ListProductoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Marca { get; set; } = default!;

        public string Categoria { get; set; } = default!;

        public decimal PrecioUnitario { get; set; }

        public int Stock { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
