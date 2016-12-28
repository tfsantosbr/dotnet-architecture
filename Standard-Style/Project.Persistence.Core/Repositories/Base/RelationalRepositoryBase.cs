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

        #region - SYNC -

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

        #region - ASYNC -

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        #endregion

        #endregion

        #region - WRITE METHODS -

        #region - SYNC -

        public new virtual void Create(TEntity obj)
        {
            CreateBase(obj);
            Save();
        }

        public virtual void Update(Expression<Func<TEntity, bool>> predicate, TEntity obj)
        {
            UpdateBase(predicate, obj);
            Save();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            DeleteBase(predicate);
            Save();
        }

        #endregion

        #region - ASYNC -

        public virtual async Task CreateAsync(TEntity obj)
        {
            CreateBase(obj);
            await SaveAsync();
        }

        public virtual async Task UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj)
        {
            UpdateBase(predicate, obj);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            DeleteBase(predicate);
            await SaveAsync();
        }

        #endregion

        #endregion

        #endregion

        #region - AUXILIARY METHODS -

        #region - BASE CRUD METHODS -

        private void CreateBase(TEntity obj)
        {
            base.Create(obj);
            Context.Set<TEntity>().Add(obj);
        }

        private void UpdateBase(Expression<Func<TEntity, bool>> predicate, TEntity obj)
        {
            base.Update(obj);

            Context.Entry(obj).State = EntityState.Modified;
            Context.Entry(obj).Property(p => p.CreationDate).IsModified = false;
        }

        private void DeleteBase(Expression<Func<TEntity, bool>> predicate)
        {
            Context.Set<TEntity>()
                .Where(predicate)
                .ToList()
                .ForEach(r => Context.Set<TEntity>().Remove(r));
        }

        #endregion

        #region - SAVE METHODS -

        private int Save()
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

        private async Task<int> SaveAsync()
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