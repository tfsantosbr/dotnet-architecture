using System;

namespace Project.UnitOfWork.Core
{
    public interface IResolver
    {
        TDependency Resolve<TDependency>(Type type);
    }
}
