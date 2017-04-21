using Project.UnitOfWorkProject.Repositories;
using System;
using System.Threading.Tasks;

namespace Project.UnitOfWorkProject.Core
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;

        int Commit();
        Task<int> CommitAsync();
    }
}