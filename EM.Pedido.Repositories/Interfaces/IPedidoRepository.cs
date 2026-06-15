using EM.Pedido.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Repositories.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedidos>
    {
        Task CreateAsync(Pedidos request);
    }
}
