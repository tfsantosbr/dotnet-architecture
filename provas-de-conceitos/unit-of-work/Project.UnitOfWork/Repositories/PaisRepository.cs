using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProjectProject.Entities;

namespace Project.UnitOfWorkProjectProject.Repositories
{
    public class PaisRepository : GenericRepository<Pais, int>, IPaisRepository
    {
        public PaisRepository(IUnitOfWorkContextAware unitOfWorkContextAware)
            : base(unitOfWorkContextAware)
        {
        }
    }
}
