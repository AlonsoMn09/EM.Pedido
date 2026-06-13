using EM.Pedido.DataAccess.Context;
using EM.Pedido.Entities;
using EM.Pedido.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Repositories.Implementations
{
    public class ProductoRepository(BdpedidosContext context) : BaseRepository<Producto>(context), IProductoRepository
    {
    }
}
 