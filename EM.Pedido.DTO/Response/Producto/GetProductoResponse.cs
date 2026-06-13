using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Response.Producto
{
    public class GetProductoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public int IdMarcaCat { get; set; }

        public int IdCategoriaCat { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int Stock { get; set; }
    }
}
