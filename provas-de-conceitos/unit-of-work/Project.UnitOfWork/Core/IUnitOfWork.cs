using System;

namespace Project.UnitOfWork.Core
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>();
        int Commit();
    }
}