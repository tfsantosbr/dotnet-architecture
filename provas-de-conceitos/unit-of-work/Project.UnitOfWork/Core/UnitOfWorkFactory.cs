using Project.UnitOfWorkProject.Contexts;
using System;
using System.Diagnostics;

namespace Project.UnitOfWorkProject.Core
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory, IDisposable
    {
        public readonly IResolver resolver;

        public UnitOfWorkFactory(IResolver resolver)
        {
            Debug.Print("[UnitOfWorkFactory] Started...");

            this.resolver = resolver;
        }

        public IUnitOfWork Create()
        {
            // TODO: Remover acoplamento
            return new UnitOfWork(new UsuarioDbContext(), resolver);
        }

        public void Dispose()
        {
            Debug.Print("[UnitOfWorkFactory] Disposed!");
            GC.SuppressFinalize(this);
        }
    }
}
