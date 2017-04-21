using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Repositories;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Project.UnitOfWorkProject.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly DbContext context;
        private readonly IServiceProvider container;

        public UnitOfWork(DbContext context, IServiceProvider container)
        {
            this.context = context;
            this.container = container;
        }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            var repository = (TRepository)container.GetService(typeof(TRepository));
            return repository;
        }

        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : Entity
        {
            return context.Set<TEntity>();
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            _disposed = true;
        }


    }
}
