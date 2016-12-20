using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project.Models.Core.Entities.Base;
using Project.Models.Core.Exceptions;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Repositories.Base
{
    /// <summary>
    ///     REPOSITORY BASE CLASS
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public abstract class RepositoryRelationalBase<TEntity> : RepositoryBase<TEntity>, IRepositoryBase<TEntity>, IRepositoryBaseAsync<TEntity>
        where TEntity : EntityBase
    {
        #region - PROPERTIES -

        public DbContext Context;

        #endregion

        #region - CONSTRUCTORS -

        protected RepositoryRelationalBase(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region - MAIN METHODS -

        #region - READ METHODS -

        public virtual TEntity Read(params object[] key)
        {
            return Context.Set<TEntity>().Find(key);
        }

        public virtual async Task<TEntity> ReadAsync(params object[] key)
        {
            return await Context.Set<TEntity>().FindAsync(key);
        }

        public virtual IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Query(Func<TEntity, bool> predicate)
        {
            return Query().Where(predicate).AsQueryable();
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        #endregion

        #region - WRITE METHODS -

        public new virtual void Create(TEntity obj)
        {
            base.Create(obj);

            Context.Set<TEntity>().Add(obj);
        }

        public new virtual void Update(TEntity obj)
        {
            base.Update(obj);

            Context.Entry(obj).State = EntityState.Modified;
            Context.Entry(obj).Property(p => p.CreationDate).IsModified = false;
        }

        public virtual void Delete(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Deleted;
        }

        public virtual void Delete(Func<TEntity, bool> predicate)
        {
            Context.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(r => Context.Set<TEntity>().Remove(r));
        }

        public virtual int Save()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new RecordConcurrencyException(ex.Message);
            }
        }

        public virtual async Task<int> SaveAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new RecordConcurrencyException(ex.Message);
            }
        }

        #endregion

        #endregion
    }
}