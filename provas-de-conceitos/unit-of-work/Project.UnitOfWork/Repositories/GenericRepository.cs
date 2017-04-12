using Project.UnitOfWork.Core;
using Project.UnitOfWork.Entities;
using System;
using System.Data.Entity;

namespace Project.UnitOfWork.Repositories
{
    public abstract class GenericRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>
        where TEntity : Entity<TIdentifier>
        where TIdentifier : IConvertible
    {
        private readonly IUnitOfWorkContextAware _unitOfWorkContextAware;
        private IDbSet<TEntity> DbSet => _unitOfWorkContextAware.GetDbSet<TEntity>();

        protected GenericRepository(IUnitOfWorkContextAware unitOfWorkContextAware)
        {
            _unitOfWorkContextAware = unitOfWorkContextAware;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public TEntity Get(TIdentifier id)
        {
            return DbSet.Find(id);
        }
    }
}
