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
    public abstract class RepositoryMongoBase<TEntity> : RepositoryBase<TEntity>, IRepositoryMongoBase<TEntity>, IRepositoryMongoBaseAsync<TEntity>
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
            Create(obj);
            Context.GetCollection<TEntity>().InsertOneAsync(obj);
        }

        public virtual async Task CreateAsync(TEntity obj)
        {
            Create(obj);
            await Context.GetCollection<TEntity>().InsertOneAsync(obj);
        }

        public virtual void Update(Expression<Func<TEntity, bool>> predicate, TEntity obj)
        {
            Update(obj);
            Context.GetCollection<TEntity>().ReplaceOne(predicate, obj);
        }

        public virtual async Task UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj)
        {
            Update(obj);
            await Context.GetCollection<TEntity>().ReplaceOneAsync(predicate, obj);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Context.GetCollection<TEntity>().DeleteOne(predicate);
        }

        public virtual void DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Context.GetCollection<TEntity>().DeleteOneAsync(predicate);
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
