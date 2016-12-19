using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project.Models.Core.Entities.Base;

namespace Project.Persistence.Core.Interfaces.Base
{
    interface IRepositoryMongoBaseAsync<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        #region - READ METHODS -

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
