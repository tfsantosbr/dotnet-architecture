using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project.Models.Core.Entities.Base;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Repositories.Base
{
    /// <summary>
    ///     REPOSITORY BASE CLASS
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IRepositoryBaseAsync<TEntity>
        where TEntity : EntityBase
    {
        public virtual void Create(TEntity obj)
        {
            obj.CreationDate = DateTime.Now;
            obj.ModificationDate = DateTime.Now;
        }

        // not implemented

        public void Delete(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Read(params object[] key)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> ReadAsync(params object[] key)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}