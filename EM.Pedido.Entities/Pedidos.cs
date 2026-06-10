using System;
using System.Collections.Generic;

namespace EM.Pedido.Entities;

public partial class Pedidos
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public decimal TotalBruto { get; set; }

    public decimal TotalNeto { get; set; }

    public decimal Adelanto { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
