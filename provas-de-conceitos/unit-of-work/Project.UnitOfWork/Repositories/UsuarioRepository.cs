using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProjectProject.Entities;

namespace Project.UnitOfWorkProjectProject.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWorkContextAware unitOfWorkContextAware)
            : base(unitOfWorkContextAware)
        {
        }
    }
}
