using System;

namespace Project.UnitOfWorkProjectProject.Core
{
    public interface IResolver
    {
        TDependency Resolve<TDependency>(Type type);
    }
}
