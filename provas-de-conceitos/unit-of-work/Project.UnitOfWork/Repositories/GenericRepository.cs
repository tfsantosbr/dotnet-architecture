using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Entities;
using System;
using System.Data.Entity;

namespace Project.UnitOfWorkProject.Repositories
{
    public abstract class GenericRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>
        where TEntity : Entity<TIdentifier>
        where TIdentifier : IConvertible
    {
        private IUnitOfWorkContextAware unitOfWorkContextAware;
        private IDbSet<TEntity> DbSet => unitOfWorkContextAware.GetDbSet<TEntity>();

        public void SetUnitOfWork(IUnitOfWorkContextAware unitOfWorkContextAware)
        {
            this.unitOfWorkContextAware = unitOfWorkContextAware;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

    }
}
