using Project.UnitOfWork.Core;
using Project.UnitOfWork.Entities;

namespace Project.UnitOfWork.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWorkContextAware unitOfWorkContextAware)
            : base(unitOfWorkContextAware)
        {
        }
    }
}
