namespace Project.UnitOfWork.Services
{
    internal interface IRepository<in TEntity>
    {
        void Add(TEntity entity);
    }
}