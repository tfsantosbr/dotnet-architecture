using Project.UnitOfWorkProject.Contexts;
using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Repositories;
using System;
using System.Data.Entity;

namespace Project.UnitOfWorkProject.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly UsuarioDbContext _context;

        public UnitOfWork(UsuarioDbContext context)
        {
            _context = context;
        }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            var repository = Activator.CreateInstance<TRepository>();
            return repository;
        }

        public int Commit()
        {
            return _context.SaveChanges();
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
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : Entity
        {
            return _context.Set<TEntity>();
        }
    }
}
