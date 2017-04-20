using Project.UnitOfWorkProject.Contexts;
using System;

namespace Project.UnitOfWorkProject.Core
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public readonly IServiceProvider container;

        public UnitOfWorkFactory(IServiceProvider container)
        {
            this.container = container;
        }

        public IUnitOfWork Create()
        {
            // TODO: Remover acoplamento
            return new UnitOfWork(new UsuarioDbContext(), container);
        }
    }
}
