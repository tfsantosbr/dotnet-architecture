using System;
using System.Linq;
using System.Linq.Expressions;
using Project.Models.Core.Entities.Base;

namespace Project.Persistence.Core.Interfaces.Base
{
    /// <summary>
    ///     REPOSITORY BASE INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public interface IRepositoryRelationalBase<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        #region - WRITE METHODS -

        void Create(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        void Delete(Func<TEntity, bool> predicate);

        int Save();

        #endregion

        #region - READ METHODS -

        IQueryable<TEntity> Query();

        IQueryable<TEntity> Query(Func<TEntity, bool> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Read(params object[] key);

        #endregion
    }
}