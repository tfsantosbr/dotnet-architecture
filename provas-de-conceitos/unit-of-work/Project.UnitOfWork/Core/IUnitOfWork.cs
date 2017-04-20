using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Repositories;
using System;
using System.Data.Entity;

namespace Project.UnitOfWorkProject.Core
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : Entity;

        int Commit();
    }
}