using Project.UnitOfWorkProject.Contexts;
using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Repositories;
using Project.UnitOfWorkProject.Services;
using SimpleInjector;
using System;

namespace Project.UnitOfWorkProject.IoC
{
    public class Bootstrapper
    {
        public static void Bootstrap(Container container)
        {
            // core
            var resolver = new Resolver(container);
            container.RegisterSingleton<IResolver>(resolver);
            container.RegisterSingleton<Func<IUnitOfWorkContextAware>>(() => new UnitOfWork(new UsuarioDbContext(), resolver));

            // repositories
            container.Register(typeof(IRepository<,>), new[] { typeof(GenericRepository<,>).Assembly }, Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
        }
    }
}
