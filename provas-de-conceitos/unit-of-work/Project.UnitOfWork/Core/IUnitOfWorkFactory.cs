namespace Project.UnitOfWork.Contexts
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}