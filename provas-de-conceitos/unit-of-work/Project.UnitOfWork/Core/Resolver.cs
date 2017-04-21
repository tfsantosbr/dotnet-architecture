using System;

namespace Project.UnitOfWorkProject.Core
{
    public class Resolver : IResolver
    {
        public IServiceProvider provider;

        public Resolver(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public TDependency Resolve<TDependency>(Type type)
        {
            return (TDependency)provider.GetService(type);
        }
    }
}
