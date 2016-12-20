using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities.Base;
using Project.Models.Core.Exceptions;
using Project.Persistence.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Domain.Core.Domains.Base
{
    /// <summary>
    ///     DOMAIN BASE CLASS
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>
    /// <typeparam name="TRepository">RepositoryBase Type</typeparam>

    public abstract class DomainBase<TEntity, TRepository> : IDomainBase<TEntity>, IDomainBaseAsync<TEntity>
        where TEntity : EntityBase
        where TRepository : IRepositoryRelationalBase<TEntity>, IRepositoryRelationalBaseAsync<TEntity>
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

        public virtual TEntity Read(params object[] key)
        {
            var obj = Repository.Read(key);

            if (obj != null && VisibleRecordses == VisibleRecords.Active && obj.ExclusionDate != null)
                throw new InactiveRecordException();

            return obj;
        }

        public virtual async Task<TEntity> ReadAsync(params object[] key)
        {
            var obj = await Repository.ReadAsync(key);

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

        public virtual IEnumerable<TEntity> List(Func<TEntity, bool> predicate)
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

        public virtual async Task<IEnumerable<TEntity>> ListAsync(Func<TEntity, bool> predicate)
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

        public virtual bool Create(TEntity obj)
        {
            Repository.Create(obj);
            return Repository.Save() > 0;
        }

        public virtual bool Create(IEnumerable<TEntity> objectList)
        {
            foreach (var obj in objectList)
            {
                Repository.Create(obj);
            }

            return Repository.Save() > 0;
        }

        public virtual async Task<bool> CreateAsync(TEntity obj)
        {
            Repository.Create(obj);
            return await Repository.SaveAsync() > 0;
        }

        public virtual async Task<bool> CreateAsync(IEnumerable<TEntity> objectList)
        {
            foreach (var obj in objectList)
            {
                Repository.Create(obj);
            }

            return await Repository.SaveAsync() > 0;
        }

        #endregion

        #region - UPDATE -

        public virtual bool Update(TEntity obj)
        {
            Repository.Update(obj);
            return Repository.Save() > 0;
        }

        public virtual bool Update(IEnumerable<TEntity> objectList)
        {
            foreach (var obj in objectList)
            {
                obj.ModificationDate = DateTime.Now;

                Repository.Update(obj);
            }

            return Repository.Save() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity obj)
        {
            Repository.Update(obj);
            return await Repository.SaveAsync() > 0;
        }

        public virtual async Task<bool> UpdateAsync(IEnumerable<TEntity> objectList)
        {
            foreach (var obj in objectList)
            {
                obj.ModificationDate = DateTime.Now;

                Repository.Update(obj);
            }

            return await Repository.SaveAsync() > 0;
        }

        #endregion

        #region - ACTIVE -

        public virtual bool Active(params object[] key)
        {
            var obj = Repository.Read(key);
            obj.ExclusionDate = null;
            Repository.Update(obj);

            return Repository.Save() > 0;
        }

        public virtual bool Active(Func<TEntity, bool> predicate)
        {
            foreach (var obj in Repository.Query(predicate).ToList())
            {
                obj.ExclusionDate = null;
                Repository.Update(obj);
            }

            return Repository.Save() > 0;
        }

        public virtual async Task<bool> ActiveAsync(params object[] key)
        {
            var obj = Repository.Read(key);
            obj.ExclusionDate = null;
            Repository.Update(obj);

            return await Repository.SaveAsync() > 0;
        }

        public virtual async Task<bool> ActiveAsync(Func<TEntity, bool> predicate)
        {
            foreach (var obj in Repository.Query(predicate).ToList())
            {
                obj.ExclusionDate = null;
                Repository.Update(obj);
            }

            return await Repository.SaveAsync() > 0;
        }

        #endregion

        #region - INACTIVE -

        public virtual bool Inactive(params object[] key)
        {
            var obj = Repository.Read(key);
            obj.ExclusionDate = DateTime.Now;
            Repository.Update(obj);

            return Repository.Save() > 0;
        }

        public virtual bool Inactive(Func<TEntity, bool> predicate)
        {
            foreach (var obj in Repository.Query(predicate).ToList())
            {
                obj.ExclusionDate = DateTime.Now;
                Repository.Update(obj);
            }

            return Repository.Save() > 0;
        }

        public virtual async Task<bool> InactiveAsync(params object[] key)
        {
            var obj = Repository.Read(key);
            obj.ExclusionDate = DateTime.Now;
            Repository.Update(obj);

            return await Repository.SaveAsync() > 0;
        }

        public virtual async Task<bool> InactiveAsync(Func<TEntity, bool> predicate)
        {
            foreach (var obj in Repository.Query(predicate).ToList())
            {
                obj.ExclusionDate = DateTime.Now;
                Repository.Update(obj);
            }

            return await Repository.SaveAsync() > 0;
        }

        #endregion

        #region - DELETE -

        public virtual bool Delete(TEntity obj)
        {
            Repository.Delete(obj);

            return Repository.Save() > 0;
        }

        public virtual bool Delete(IEnumerable<TEntity> objectList)
        {
            foreach (var obj in objectList)
            {
                Repository.Delete(obj);
            }

            return Repository.Save() > 0;
        }

        public virtual bool Delete(Func<TEntity, bool> predicate)
        {
            Repository.Delete(predicate);
            return Repository.Save() > 0;
        }

        public virtual async Task<bool> DeleteAsync(TEntity obj)
        {
            Repository.Delete(obj);

            return await Repository.SaveAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(IEnumerable<TEntity> objectList)
        {
            foreach (var obj in objectList)
            {
                Repository.Delete(obj);
            }

            return await Repository.SaveAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(Func<TEntity, bool> predicate)
        {
            Repository.Delete(predicate);
            return await Repository.SaveAsync() > 0;
        }

        #endregion

        #endregion

        #endregion

        //#region - AUXILIARY METHODS -

        //#region - DISPOSE -

        //~DomainBase()
        //{
        //    Dispose(false);
        //}

        //public virtual void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposing) return;
        //    //Repository?.Dispose();
        //}

        //#endregion

        //#endregion
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