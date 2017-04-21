using Project.UnitOfWorkProjectProject.Core;
using Project.UnitOfWorkProjectProject.Entities;
using System.Data.Entity;

namespace Project.UnitOfWorkProject.Core
{
    public interface IUnitOfWorkContextAware : IUnitOfWork
    {
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : Entity;
    }
}
