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
            container.Register<DbContext, UsuarioDbContext>(Lifestyle.Scoped);
            container.RegisterSingleton<IServiceProvider, Container>();
            container.RegisterSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register(typeof(IRepository<,>), new[] { typeof(GenericRepository<,>).Assembly }, Lifestyle.Scoped);

            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);

            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
        }
    }
}
