using Project.UnitOfWork.Contexts;

namespace Project.UnitOfWork.Core
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IResolver _resolver;

        public UnitOfWorkFactory(IResolver resolver)
        {
            _resolver = resolver;
        }

        public IUnitOfWork Create()
        {
            // TODO: Remover acoplamento
            return new UnitOfWork(new UsuarioDbContext(), _resolver);
        }
    }
}
