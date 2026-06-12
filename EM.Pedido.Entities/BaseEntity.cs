using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}
