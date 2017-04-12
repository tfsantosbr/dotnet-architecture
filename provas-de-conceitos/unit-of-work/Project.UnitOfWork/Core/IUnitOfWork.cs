using Project.UnitOfWork.Repositories;
using System;

namespace Project.UnitOfWork.Core
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;

        int Commit();
    }
}