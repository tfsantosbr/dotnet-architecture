using AutoMapper;
using Owin;
using Project.API.Base.MapperAdapters;
using Project.API.Publicacoes.Mappers;
using Project.Domain.Publicacoes.Domains;
using Project.Domain.Publicacoes.Interfaces;
using Project.Persistence.Publicacoes.Contexts;
using Project.Persistence.Publicacoes.Interfaces;
using Project.Persistence.Publicacoes.Repositories;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;
using System.Data.Entity;
using System.Web.Http;

namespace Project.API.Publicacoes
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
            container.Register<DbContext, PublicacoesContext>(Lifestyle.Scoped);
            #endregion

            #region - REPOSITORIES -
            container.Register<IConteudoRepository, ConteudoRepository>(Lifestyle.Scoped);
            #endregion

            #region - DOMAINS -
            container.Register<IConteudoDomain, ConteudoDomain>(Lifestyle.Scoped);
            #endregion
        }
    }
}
