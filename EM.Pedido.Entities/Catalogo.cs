using System;
using System.Collections.Generic;

namespace EM.Pedido.Entities;

public partial class Catalogo : BaseEntity
{    
    public string Codigo { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CatalogoDetalle> CatalogoDetalles { get; set; } = new List<CatalogoDetalle>();
}
