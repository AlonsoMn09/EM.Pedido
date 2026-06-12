using System;
using System.Collections.Generic;

namespace EM.Pedido.Entities;

public partial class Cliente : BaseEntity
{
    public string RazonSocial { get; set; } = null!;

    /// <summary>
    /// Tipo de documento del cliente
    /// </summary>
    public int IdTipoDocumentoCat { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string Representante { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public int IdRubroCat { get; set; }

    public virtual CatalogoDetalle IdRubroCatNavigation { get; set; } = null!;

    public virtual CatalogoDetalle IdTipoDocumentoCatNavigation { get; set; } = null!;

    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
}
