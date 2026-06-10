using System;
using System.Collections.Generic;

namespace EM.Pedido.Entities;

public partial class CatalogoDetalle
{
    public int Id { get; set; }

    public int IdCatalogo { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Valor { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<Cliente> ClienteIdRubroCatNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClienteIdTipoDocumentoCatNavigations { get; set; } = new List<Cliente>();

    public virtual Catalogo IdCatalogoNavigation { get; set; } = null!;

    public virtual ICollection<Producto> ProductoIdCategoriaCatNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Producto> ProductoIdMarcaCatNavigations { get; set; } = new List<Producto>();
}
