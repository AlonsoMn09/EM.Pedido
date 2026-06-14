using EM.Pedido.DataAccess.Context;
using EM.Pedido.Entities;
using EM.Pedido.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Repositories.Implementations
{
    public class CatalogoDetalleRepository(BdpedidosContext context) : BaseRepository<CatalogoDetalle>(context), ICatalogoDetalleRepository
    {
        /*private readonly BdpedidosContext _context;
        public CatalogoRepository(BdpedidosContext context) : base(context)
        {
            _context = context;
        }*/
    }
}
