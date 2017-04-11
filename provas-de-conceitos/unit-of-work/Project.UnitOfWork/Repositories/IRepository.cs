namespace Project.UnitOfWork.Services
{
    internal interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        TEntity Get(int id);
    }
}