using Project.UnitOfWork.Entities;
using System;

namespace Project.UnitOfWork.Repositories
{
    public interface IRepository { }

    public interface IRepository<TEntity, in TIdentifier> : IRepository
        where TEntity : Entity<TIdentifier>
        where TIdentifier : IConvertible
    {
        void Add(TEntity entity);

        TEntity Get(TIdentifier id);
    }
}