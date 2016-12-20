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

    public interface IRepositoryRelationalBaseAsync<TEntity> : IRepositoryBaseAsync<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        #region - WRITE METHODS -

        Task<int> SaveAsync();

        #endregion

        #region - READ METHODS -

        Task<TEntity> ReadAsync(params object[] key);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}