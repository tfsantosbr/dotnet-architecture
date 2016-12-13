using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartup("PublicacoesConfiguration", typeof(Project.API.Publicacoes.Startup))]

namespace Project.API.Publicacoes
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            AuthenticationConfig.ConfigureOAuth(app);
            DependecyConfig.ConfigureDependencies(config, app);

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}