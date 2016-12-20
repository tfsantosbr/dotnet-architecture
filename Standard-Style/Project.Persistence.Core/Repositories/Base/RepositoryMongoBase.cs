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
    public abstract class RepositoryMongoBase<TEntity> : RepositoryBase<TEntity>, IRepositoryBase<TEntity>, IRepositoryBaseAsync<TEntity>
        where TEntity : EntityBase
    {
        #region - PROPERTIES -

        public MongoContextBase Context;

        #endregion

        #region - CONSTRUCTORS -

        public RepositoryMongoBase(MongoContextBase context)
        {
            Context = context;
        }

        #endregion

        #region - MAIN METHODS -

        #region - WRITE METHODS -

        public new virtual void Create(TEntity obj)
        {
            base.Create(obj);
            Context.GetCollection<TEntity>().InsertOneAsync(obj);
        }

        public virtual async Task CreateAsync(TEntity obj)
        {
            base.Create(obj);
            await Context.GetCollection<TEntity>().InsertOneAsync(obj);
        }

        #endregion

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

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.GetCollection<TEntity>().Find(predicate).SingleOrDefaultAsync();
        }

        #endregion

        #endregion

        public virtual TEntity Read(params object[] key)
        {
            throw new NotImplementedException();
        }

        public virtual int Save()
        {
            throw new NotImplementedException();
        }

        public new virtual void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> ReadAsync(params object[] key)
        {
            throw new NotImplementedException();
        }
    }
}
