using Project.UnitOfWork.Entities;
using Project.UnitOfWork.Services;
using System;
using System.Data.Entity;

namespace Project.UnitOfWork.Contexts
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : Entity;

        int Commit();
    }
}