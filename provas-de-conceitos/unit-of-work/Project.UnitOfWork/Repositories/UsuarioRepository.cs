using Project.UnitOfWork.Contexts;
using Project.UnitOfWork.Entities;
using Project.UnitOfWork.Services;

namespace Project.UnitOfWork.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
