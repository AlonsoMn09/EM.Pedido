using EM.Pedido.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EM.Pedido.DTO.Request.Producto
{
    public class CreateProductoRequest
    {
        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public string Descripcion { get; set; } = null!;

        [DeniedValues(0, ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public int IdMarcaCat { get; set; }

        [DeniedValues(0, ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        public int IdCategoriaCat { get; set; }

        [DeniedValues(0, ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        [Range(0, int.MaxValue, ErrorMessage = "El campo {0} debe ser un número entero no negativo.")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = DataAnnotationsMessage.RequiredMessage)]
        [Range(0, int.MaxValue, ErrorMessage = "El campo {0} debe ser un número entero no negativo.")]
        public int Stock { get; set; }
    }
}
