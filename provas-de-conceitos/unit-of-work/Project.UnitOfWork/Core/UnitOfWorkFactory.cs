using System;

namespace Project.UnitOfWork.Contexts
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider _provider;

        public UnitOfWorkFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IUnitOfWork Create()
        {
            // TODO: Remover acoplamento
            return new UnitOfWork(new UsuarioDbContext(), _provider);
        }
    }
}
