using Project.UnitOfWorkProject.Contexts;
using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Repositories;
using Project.UnitOfWorkProject.Services;
using SimpleInjector;
using System;
using System.Data.Entity;

namespace Project.UnitOfWorkProject.IoC
{
    public class Bootstrapper
    {
        public static void Bootstrap(Container container)
        {
            // contexto
            container.Register<DbContext, UsuarioDbContext>(Lifestyle.Scoped);

            // core
            container.RegisterSingleton<IServiceProvider, Container>();
            container.RegisterSingleton<IResolver, Resolver>();
            container.RegisterSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            // repositories
            container.Register(typeof(IRepository<,>), new[] { typeof(GenericRepository<,>).Assembly }, Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
        }
    }
}
