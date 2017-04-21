using System;

namespace Project.UnitOfWorkProject.Core
{
    public interface IResolver
    {
        TDependency Resolve<TDependency>(Type type);
    }
}
