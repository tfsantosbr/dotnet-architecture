using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProjectProject.Entities;
using System;
using System.Data.Entity;

namespace Project.UnitOfWorkProjectProject.Repositories
{
    public abstract class GenericRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>
        where TEntity : Entity<TIdentifier>
        where TIdentifier : IConvertible
    {
        private readonly IUnitOfWorkContextAware unitOfWorkContextAware;
        private IDbSet<TEntity> DbSet => unitOfWorkContextAware.GetDbSet<TEntity>();

        protected GenericRepository(IUnitOfWorkContextAware unitOfWorkContextAware)
        {
            this.unitOfWorkContextAware = unitOfWorkContextAware;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }
    }
}
