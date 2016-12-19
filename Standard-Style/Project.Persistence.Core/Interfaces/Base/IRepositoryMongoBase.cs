using System;
using System.Linq;
using System.Linq.Expressions;
using Project.Models.Core.Entities.Base;

namespace Project.Persistence.Core.Interfaces.Base
{
    public interface IRepositoryMongoBase<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        #region - READ METHODS -

        IQueryable<TEntity> Query();

        IQueryable<TEntity> Query(Func<TEntity, bool> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
