using Project.UnitOfWork.Contexts;
using Project.UnitOfWork.Entities;
using Project.UnitOfWork.Repositories;
using System;
using System.Data.Entity;

namespace Project.UnitOfWork.Core
{
    public class UnitOfWork : IUnitOfWorkContextAware
    {
        private bool _disposed;
        private readonly UsuarioDbContext _context;
        private readonly IResolver _resolver;

        public UnitOfWork(UsuarioDbContext context, IResolver resolver)
        {
            _context = context;
            _resolver = resolver;
        }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            return _resolver.Resolve<TRepository>(typeof(TRepository));
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
