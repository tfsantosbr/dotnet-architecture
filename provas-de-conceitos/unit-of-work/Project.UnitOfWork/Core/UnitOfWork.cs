using System;

namespace Project.UnitOfWork.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly UsuarioDbContext _context;

        public UnitOfWork(UsuarioDbContext context)
        {
            _context = context;
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

        public TRepository GetRepository<TRepository>()
        {
            throw new NotImplementedException();
        }
    }
}
