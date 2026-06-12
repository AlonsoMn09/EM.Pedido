using EM.Pedido.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EM.Pedido.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync();
        Task<TEntity?> GetByAsync(int id);
        Task<ICollection<TEntity>> ListAsync();
        Task<(ICollection<TResult> Result, int TotalRows)> ListAsync<TResult, TKey>
            (
                Expression<Func<TEntity, bool>> predicate,
                Expression<Func<TEntity, TResult>> selector,
                Expression<Func<TEntity, TKey>> orderBy,
                int page = 1, int pageSize = 10
            );
        Task DeleteAsync(int id);
    }
}
