using System;
using System.Collections.Generic;

namespace EM.Pedido.Entities;

public partial class Catalogo
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<CatalogoDetalle> CatalogoDetalles { get; set; } = new List<CatalogoDetalle>();
}
