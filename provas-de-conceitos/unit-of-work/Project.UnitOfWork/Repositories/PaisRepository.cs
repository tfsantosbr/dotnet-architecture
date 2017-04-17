using Project.UnitOfWork.Core;
using Project.UnitOfWork.Entities;

namespace Project.UnitOfWork.Repositories
{
    public class PaisRepository : GenericRepository<Pais, int>, IPaisRepository
    {
        public PaisRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
