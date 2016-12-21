using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project.Models.Core.Entities.Base;

namespace Project.Domain.Core.Interfaces.Base
{
    /// <summary>
    ///     DOMAIN BASE ASYNC INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public interface IDomainBaseAsync<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        Task CreateAsync(TEntity obj);
        Task CreateAsync(IEnumerable<TEntity> objectList);

        Task UpdateAsync(TEntity obj);
        Task UpdateAsync(IEnumerable<TEntity> objectList);

        Task DeleteAsync(TEntity obj);
        Task DeleteAsync(IEnumerable<TEntity> objectList);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task ActiveAsync(Expression<Func<TEntity, bool>> predicate);

        Task InactiveAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> ListAsync();
        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);
    }
}