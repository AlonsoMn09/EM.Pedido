using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Response.Catalogo
{
    public class ListCatalogoByCodigoResponse
    {
        public int Id { get; set; }
        public string CodigoPadre { get; set; } = default!;
        public string Codigo { get; set; } = default!;
        public string Valor { get; set; } = default!;
    }
}
