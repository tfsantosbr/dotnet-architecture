using AutoMapper;
using Owin;
using Project.API.Base.MapperAdapters;
using Project.API.Universidade.Mappers;
using Project.Domain.Universidade.Domains;
using Project.Domain.Universidade.Interfaces;
using Project.Persistence.Universidade.Contexts;
using Project.Persistence.Universidade.Interfaces;
using Project.Persistence.Universidade.Repositories;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;
using System.Data.Entity;
using System.Web.Http;

namespace Project.API.Universidade
{
    public class DependecyConfig
    {
        public static void ConfigureDependencies(HttpConfiguration config, IAppBuilder app)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            ConfigContainer(container);
            container.Verify();

            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        public static void ConfigContainer(Container container)
        {
            #region - MAPPER -
            var mapperConfig = AutoMapperConfig.GetMapperConfiguration();
            container.RegisterSingleton<IConfigurationProvider>(mapperConfig);
            container.Register(() => mapperConfig.CreateMapper());
            container.Register<IMapperAdapter, AutoMapperAdapter>();
            #endregion

            #region - CONTEXTS -
            container.Register<DbContext, UniversidadeContext>(Lifestyle.Scoped);
            #endregion

            #region - REPOSITORIES -
            container.Register<IEstudanteRepository, EstudanteRepository>(Lifestyle.Scoped);
            #endregion

            #region - DOMAINS -
            container.Register<IEstudanteDomain, EstudanteDomain>(Lifestyle.Scoped);
            #endregion
        }
    }
}
