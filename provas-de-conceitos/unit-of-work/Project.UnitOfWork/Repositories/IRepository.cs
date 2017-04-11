using Project.UnitOfWork.Entities;

namespace Project.UnitOfWork.Services
{
    public interface IRepository { }

    public interface IRepository<TEntity, in TIdentity> : IRepository
        where TEntity : Entity<TIdentity>
    {
        void Add(TEntity entity);

        TEntity Get(int id);
    }
}