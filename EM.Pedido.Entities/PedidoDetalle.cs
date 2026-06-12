using System;
using System.Collections.Generic;

namespace EM.Pedido.Entities;

public partial class PedidoDetalle : BaseEntity
{    
    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal TotalBruto { get; set; }

    public decimal TotalNeto { get; set; }

    public virtual Pedidos IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
