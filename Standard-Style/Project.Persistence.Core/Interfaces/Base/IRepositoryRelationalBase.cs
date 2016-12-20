using System;
using Project.Models.Core.Entities.Base;

namespace Project.Persistence.Core.Interfaces.Base
{
    /// <summary>
    ///     REPOSITORY BASE INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public interface IRepositoryRelationalBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        #region - WRITE METHODS -

        void Update(TEntity obj);

        void Delete(TEntity obj);

        void Delete(Func<TEntity, bool> predicate);

        int Save();

        #endregion

        #region - READ METHODS -

        TEntity Read(params object[] key);

        #endregion
    }
}