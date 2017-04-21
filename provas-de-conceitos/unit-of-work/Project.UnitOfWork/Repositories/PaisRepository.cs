using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Entities;

namespace Project.UnitOfWorkProject.Repositories
{
    public class PaisRepository : GenericRepository<Pais, int>, IPaisRepository
    {
        public PaisRepository(IUnitOfWorkContextAware unitOfWorkContextAware)
            : base(unitOfWorkContextAware)
        {
        }
    }
}
