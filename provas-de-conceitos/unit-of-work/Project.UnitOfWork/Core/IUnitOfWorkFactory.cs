namespace Project.UnitOfWorkProject.Core
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}