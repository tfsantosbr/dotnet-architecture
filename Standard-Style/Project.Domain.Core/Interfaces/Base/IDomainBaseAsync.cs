using System;
using System.Collections.Generic;
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
        Task<bool> CreateAsync(TEntity obj);
        Task<bool> CreateAsync(IEnumerable<TEntity> objectList);

        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> UpdateAsync(IEnumerable<TEntity> objectList);

        Task<bool> DeleteAsync(TEntity obj);
        Task<bool> DeleteAsync(IEnumerable<TEntity> objectList);
        Task<bool> DeleteAsync(Func<TEntity, bool> predicate);

        Task<bool> ActiveAsync(params object[] key);
        Task<bool> ActiveAsync(Func<TEntity, bool> predicate);

        Task<bool> InactiveAsync(params object[] key);
        Task<bool> InactiveAsync(Func<TEntity, bool> predicate);

        Task<TEntity> ReadAsync(params object[] key);

        Task<IEnumerable<TEntity>> ListAsync();
        Task<IEnumerable<TEntity>> ListAsync(Func<TEntity, bool> predicate);
    }
}