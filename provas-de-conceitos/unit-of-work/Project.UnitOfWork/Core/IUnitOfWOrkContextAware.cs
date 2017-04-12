using Project.UnitOfWork.Entities;
using System.Data.Entity;

namespace Project.UnitOfWork.Core
{
    public interface IUnitOfWorkContextAware
    {
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : Entity;
    }
}
