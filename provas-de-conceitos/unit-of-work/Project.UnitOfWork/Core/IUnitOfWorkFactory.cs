namespace Project.UnitOfWork.Core
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}