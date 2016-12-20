using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project.Models.Core.Entities.Base;

namespace Project.Persistence.Core.Interfaces.Base
{
    /// <summary>
    ///    REPOSITORY BASE ASYNC INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public interface IRepositoryMongoBaseAsync<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        #region - WRITE METHODS -

        Task CreateAsync(TEntity obj);

        Task UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj);

        Task DeleteOneAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region - READ METHODS -

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}