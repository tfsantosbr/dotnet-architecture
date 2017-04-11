using Project.UnitOfWork.Services;
using System;

namespace Project.UnitOfWork.Contexts
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
        int Commit();
    }
}