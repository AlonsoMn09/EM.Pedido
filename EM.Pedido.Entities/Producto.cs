using System;
using System.Collections.Generic;

namespace EM.Pedido.Entities;

public partial class Producto : BaseEntity
{    
    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int IdMarcaCat { get; set; }

    public int IdCategoriaCat { get; set; }

    public decimal PrecioUnitario { get; set; }

    public int Stock { get; set; }

    public virtual CatalogoDetalle IdCategoriaCatNavigation { get; set; } = null!;

    public virtual CatalogoDetalle IdMarcaCatNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
