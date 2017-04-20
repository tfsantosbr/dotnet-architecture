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
        private readonly IUnitOfWork _unitOfWork;
        private IDbSet<TEntity> DbSet => _unitOfWork.GetDbSet<TEntity>();

        protected GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }
    }
}
