using System;
using System.Diagnostics;

namespace Project.UnitOfWorkProject.Core
{
    public class Resolver : IResolver, IDisposable
    {
        public IServiceProvider provider;

        public Resolver(IServiceProvider provider)
        {
            Debug.Print("[Resolver] Started...");
            this.provider = provider;
        }

        public void Dispose()
        {
            Debug.Print("[Resolver] Disposed!");
            GC.SuppressFinalize(this);
        }

        public TDependency Resolve<TDependency>(Type type)
        {
            return (TDependency)provider.GetService(type);
        }
    }
}
