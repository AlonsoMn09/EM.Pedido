using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Request.Producto
{
    public class UpdateProductoRequest
    {
        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public int IdMarcaCat { get; set; }

        public int IdCategoriaCat { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int Stock { get; set; }
    }
}
