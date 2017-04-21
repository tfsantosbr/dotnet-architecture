using Project.UnitOfWorkProjectProject.Repositories;
using System;
using System.Threading.Tasks;

namespace Project.UnitOfWorkProjectProject.Core
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;

        int Commit();
        Task<int> CommitAsync();
    }
}