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

    public interface IRepositoryBaseAsync<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        #region - WRITE METHODS -

        Task CreateAsync(TEntity obj);

        Task UpdateAsync(TEntity obj);

        Task DeleteAsync(TEntity obj);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region - READ METHODS -

        // todo criar os metodos assincronos de read

        #endregion
    }
}