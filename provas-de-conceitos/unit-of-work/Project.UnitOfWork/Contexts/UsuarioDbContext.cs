using System;

namespace Project.UnitOfWork.Contexts
{
    public class UsuarioDbContext : IDisposable
    {
        // TODO: remover depois, pois irá herdar de DbContext
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        // TODO: remover depois, pois irá herdar de DbContext
        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}