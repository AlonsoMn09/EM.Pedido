using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioCreacion { get; set; } = Environment.UserName;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}
