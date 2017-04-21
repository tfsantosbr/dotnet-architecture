using Project.UnitOfWorkProjectProject.Entities;
using System;

namespace Project.UnitOfWorkProjectProject.Repositories
{
    public interface IRepository
    {
        //void SetUnitOfWork(IUnitOfWork unitOfWork);
    }

    public interface IRepository<TEntity, in TIdentifier> : IRepository
        where TEntity : Entity<TIdentifier>
        where TIdentifier : IConvertible
    {
        void Add(TEntity entity);
    }
}