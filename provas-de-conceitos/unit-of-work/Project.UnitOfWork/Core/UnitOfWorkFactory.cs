using Project.UnitOfWorkProject.Contexts;

namespace Project.UnitOfWorkProject.Core
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            // TODO: Remover acoplamento
            return new UnitOfWork(new UsuarioDbContext());
        }
    }
}
