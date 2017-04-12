using SimpleInjector;
using System;

namespace Project.UnitOfWork.Core
{
    public class Resolver : IResolver
    {
        public readonly Container _container;

        public Resolver(Container container)
        {
            _container = container;
        }

        public TDependency Resolve<TDependency>(Type type)
        {
            return (TDependency)_container.GetInstance(type);
        }
    }
}
