using System;
using System.Collections.Generic;

namespace EM.Pedido.Entities;

public partial class CatalogoDetalle : BaseEntity
{
    public int IdCatalogo { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Valor { get; set; }    

    public virtual ICollection<Cliente> ClienteIdRubroCatNavigations { get; set; } = new List<Cliente>();

    public virtual ICollection<Cliente> ClienteIdTipoDocumentoCatNavigations { get; set; } = new List<Cliente>();

    public virtual Catalogo IdCatalogoNavigation { get; set; } = null!;

    public virtual ICollection<Producto> ProductoIdCategoriaCatNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Producto> ProductoIdMarcaCatNavigations { get; set; } = new List<Producto>();
}
