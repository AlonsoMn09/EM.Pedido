using EM.Pedido.DataAccess.Context;
using EM.Pedido.Entities;
using EM.Pedido.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Repositories.Implementations
{
    public class PedidoRepository(BdpedidosContext context) : BaseRepository<Pedidos>(context), IPedidoRepository
    {
        //REGISTRAR PEDIDO , DETALLE, ACTUALIZAR PRODUCTOS DENTRO DE UNA TRANSACCION
        public async Task CreateAsync(Pedidos request) 
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Pedidos.AddAsync(request);
                //ACTUALIZAR STOCK DE PRODUCTOS
                foreach (var item in request.PedidoDetalles)
                {
                    var product = await _context.Productos.FirstOrDefaultAsync(p => p.Estado && p.Id == item.IdProducto);
                    if (product != null)
                    {
                        product.Stock -= Convert.ToInt32(item.Cantidad);
                    }
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
