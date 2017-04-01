using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities.Base;
using Project.Models.Core.Exceptions;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Domain.Core.Domains.Base
{
    /// <summary>
    ///     DOMAIN BASE CLASS
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>
    /// <typeparam name="TRepository">RepositoryBase Type</typeparam>

    public abstract class DomainBase<TEntity, TRepository> : IDomainBase<TEntity>, IDomainBaseAsync<TEntity>
        where TEntity : EntityBase
        where TRepository : IRepositoryBase<TEntity>, IRepositoryBaseAsync<TEntity>
    {
        #region - PROPERTIES -

        protected readonly TRepository Repository;
        protected readonly VisibleRecords VisibleRecordses;

        #endregion

        #region - CONSTRUCTORS -

        protected DomainBase(TRepository repository)
            : this(repository, VisibleRecords.Active)
        {
        }

        protected DomainBase(TRepository repository, VisibleRecords visibleRecordses)
        {
            Repository = repository;
            VisibleRecordses = visibleRecordses;
        }

        #endregion

        #region - MAIN METHODS -

        #region - READ METHODS -

        #region - READ -

        public virtual TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            var obj = Repository.SingleOrDefault(predicate);

            if (obj != null && VisibleRecordses == VisibleRecords.Active && obj.ExclusionDate != null)
                throw new InactiveRecordException();

            return obj;
        }

        public virtual async Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var obj = await Repository.SingleOrDefaultAsync(predicate);

            if (obj != null && VisibleRecordses == VisibleRecords.Active && obj.ExclusionDate != null)
                throw new InactiveRecordException();

            return obj;
        }

        #endregion

        #region - LIST -

        public virtual IEnumerable<TEntity> List()
        {
            return List(null);
        }

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query;

            switch (VisibleRecordses)
            {
                case VisibleRecords.All:
                    query = Repository.Query();
                    break;

                case VisibleRecords.Active:
                    query = Repository.Query(r => r.ExclusionDate == null);
                    break;

                case VisibleRecords.Inactive:
                    query = Repository.Query(r => r.ExclusionDate != null);
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }

            return query.ToList();

        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await ListAsync(null);
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query;

            switch (VisibleRecordses)
            {
                case VisibleRecords.All:
                    query = Repository.Query();
                    break;

                case VisibleRecords.Active:
                    query = Repository.Query(r => r.ExclusionDate == null);
                    break;

                case VisibleRecords.Inactive:
                    query = Repository.Query(r => r.ExclusionDate != null);
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }

            return await query.ToListAsync();
        }

        #endregion

        #endregion

        #region - WRITE METHODS -

        #region - CREATE -

        public virtual void Create(TEntity obj)
        {
            Repository.Create(obj);
        }

        public virtual void Create(IEnumerable<TEntity> objectList)
        {
            throw new NotImplementedException();
            // todo implementar
            //foreach (var obj in objectList)
            //{
            //    Repository.Create(obj);
            //}
        }

        public virtual async Task CreateAsync(TEntity obj)
        {
            await Repository.CreateAsync(obj);
        }

        public virtual async Task CreateAsync(IEnumerable<TEntity> objectList)
        {
            await Task.Yield();
            // todo implementar
            //foreach (var obj in objectList)
            //{
            //    Repository.Create(obj);
            //}
        }

        #endregion

        #region - UPDATE -

        public virtual void Update(Expression<Func<TEntity, bool>> predicate, TEntity obj)
        {
            Repository.Update(predicate, obj);
        }

        public virtual void Update(IEnumerable<TEntity> objectList)
        {
            throw new NotImplementedException();
            // todo implementar
            //foreach (var obj in objectList)
            //{
            //    obj.ModificationDate = DateTime.Now;

            //    Repository.Update(obj);
            //}

        }

        public virtual async Task UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj)
        {
            await Repository.UpdateAsync(predicate, obj);
        }

        public virtual async Task UpdateAsync(IEnumerable<TEntity> objectList)
        {
            await Task.Yield();
            // todo implementar
            //foreach (var obj in objectList)
            //{
            //    obj.ModificationDate = DateTime.Now;

            //    Repository.Update(obj);
            //}
        }

        #endregion

        #region - ACTIVE -

        public virtual void Active(Expression<Func<TEntity, bool>> predicate)
        {
            new NotImplementedException();
            //todo implementar
            //foreach (var obj in Repository.Query(predicate).ToList())
            //{
            //    obj.ExclusionDate = null;
            //    Repository.Update(obj);
            //}

            //return Repository.Save() > 0;
        }

        public virtual async Task ActiveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await Task.Yield();
            //todo implementar
            //foreach (var obj in Repository.Query(predicate).ToList())
            //{
            //    obj.ExclusionDate = null;
            //    Repository.Update(obj);
            //}

            //return await Repository.SaveAsync() > 0;
        }

        #endregion

        #region - INACTIVE -

        public virtual void Inactive(Expression<Func<TEntity, bool>> predicate)
        {
            new NotImplementedException();
            //todo implementar
            //foreach (var obj in Repository.Query(predicate).ToList())
            //{
            //    obj.ExclusionDate = DateTime.Now;
            //    Repository.Update(obj);
            //}

            //return Repository.Save() > 0;
        }

        public virtual async Task InactiveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await Task.Yield();
            //todo implementar
            //foreach (var obj in Repository.Query(predicate).ToList())
            //{
            //    obj.ExclusionDate = DateTime.Now;
            //    Repository.Update(obj);
            //}

            //return await Repository.SaveAsync() > 0;
        }

        #endregion

        #region - DELETE -

        public virtual void Delete(IEnumerable<TEntity> objectList)
        {
            new NotImplementedException();
            //todo implementar
            //foreach (var obj in objectList)
            //{
            //    Repository.Delete(obj);
            //}

            //return Repository.Save() > 0;
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Repository.Delete(predicate);
        }

        public virtual async Task DeleteAsync(IEnumerable<TEntity> objectList)
        {
            await Task.Yield();
            //todo implementar
            //foreach (var obj in objectList)
            //{
            //    Repository.Delete(obj);
            //}

            //return await Repository.SaveAsync() > 0;
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await Repository.DeleteAsync(predicate);
        }

        #endregion

        #endregion

        #endregion
    }

    /// <summary>
    ///     VISIBLE RECORDS ENUMERATOR
    /// </summary>

    public enum VisibleRecords
    {
        All,
        Active,
        Inactive
    }
}