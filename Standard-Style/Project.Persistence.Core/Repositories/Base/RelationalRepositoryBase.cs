using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Project.Models.Core.Entities.Base;
using Project.Models.Core.Exceptions;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Repositories.Base
{
    /// <summary>
    ///     REPOSITORY BASE CLASS
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public abstract class RelationalRepositoryBase<TEntity> : RepositoryBase<TEntity>, IRepositoryBase<TEntity>, IRepositoryBaseAsync<TEntity>
        where TEntity : EntityBase
    {
        #region - PROPERTIES -

        public DbContext Context;

        #endregion

        #region - CONSTRUCTORS -

        protected RelationalRepositoryBase(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region - MAIN METHODS -

        #region - READ METHODS -

        public virtual IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return Query().Where(predicate).AsQueryable();
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        #endregion

        #region - WRITE METHODS -

        public new virtual void Create(TEntity obj)
        {
            base.Create(obj);

            Context.Set<TEntity>().Add(obj);
            Save();
        }

        public new virtual void Update(TEntity obj)
        {
            base.Update(obj);

            Context.Entry(obj).State = EntityState.Modified;
            Context.Entry(obj).Property(p => p.CreationDate).IsModified = false;

            Save();
        }

        public virtual void Delete(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Deleted;
            Save();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Context.Set<TEntity>()
                .Where(predicate)
                .ToList()
                .ForEach(r => Context.Set<TEntity>().Remove(r));

            Save();
        }

        #endregion

        #endregion

        #region - AUXILIARY METHODS -

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

        #endregion
    }
}