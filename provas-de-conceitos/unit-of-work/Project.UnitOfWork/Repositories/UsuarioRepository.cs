using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Entities;

namespace Project.UnitOfWorkProject.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWorkContextAware unitOfWorkContextAware)
            : base(unitOfWorkContextAware)
        {
        }
    }
}
