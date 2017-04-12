using Project.UnitOfWork.Entities;
using Project.UnitOfWork.Repositories;
using System;
using System.Data.Entity;

namespace Project.UnitOfWork.Core
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : Entity;

        int Commit();
    }
}