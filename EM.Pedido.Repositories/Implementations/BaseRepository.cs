using EM.Pedido.DataAccess.Context;
using EM.Pedido.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EM.Pedido.Repositories.Interfaces;

namespace EM.Pedido.Repositories.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly BdpedidosContext _context;

        public BaseRepository(BdpedidosContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetByAsync(int id)
        {
            return await _context.Set<TEntity>()
                .FirstOrDefaultAsync(p => p.Estado && p.Id == id);
        }

        public async Task<ICollection<TEntity>> ListAsync()
        {
            return await _context.Set<TEntity>()
                .Where(p => p.Estado)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<(ICollection<TResult> Result, int TotalRows)> ListAsync<TResult, TKey>
            (
                Expression<Func<TEntity, bool>> predicate,
                Expression<Func<TEntity, TResult>> selector,
                Expression<Func<TEntity, TKey>> orderBy,
                int page = 1, int pageSize = 10
            )
        { 
            var result = await _context.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .OrderBy(orderBy)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(selector)
                .ToListAsync();

            var total = await _context.Set<TEntity>()
                .Where(predicate)
                .CountAsync();

            return (result, total);
        }

        public async Task<ICollection<TResult>> ListAsync<TResult, TKey>
            (
                Expression<Func<TEntity, bool>> predicate,
                Expression<Func<TEntity, TResult>> selector,
                Expression<Func<TEntity, TKey>> orderBy
            )
        {
            return await _context.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .OrderBy(orderBy)
                .Select(selector)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id) 
        { 
            await _context.Set<TEntity>()
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(p => p.Estado, false));
        }
    }
}
