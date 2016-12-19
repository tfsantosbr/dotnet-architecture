using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Project.Models.Core.Entities.Base;
using Project.Persistence.Core.Contexts.Base;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Repositories.Base
{
    public abstract class RepositoryMongoBase<TEntity> : IRepositoryMongoBase<TEntity>, IRepositoryMongoBaseAsync<TEntity>
        where TEntity : EntityBase
    {
        #region - PROPERTIES -

        public DocumentContextBase Context;

        #endregion

        #region - CONSTRUCTORS -

        public RepositoryMongoBase(DocumentContextBase context)
        {
            Context = context;
        }

        #endregion

        #region - MAIN METHODS -

        #region - READ METHODS -

        public virtual IQueryable<TEntity> Query()
        {
            return Context.GetCollection<TEntity>().AsQueryable();
        }

        public virtual IQueryable<TEntity> Query(Func<TEntity, bool> predicate)
        {
            return Query().Where(predicate).AsQueryable();
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.GetCollection<TEntity>().Find(predicate).SingleOrDefault();
        }

        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.GetCollection<TEntity>().Find(predicate).SingleOrDefaultAsync();
        }

        #endregion

        #endregion
    }
}
