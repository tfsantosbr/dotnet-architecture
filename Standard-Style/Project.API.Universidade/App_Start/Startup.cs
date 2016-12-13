using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartup("UniversidadeConfiguration", typeof(Project.API.Universidade.Startup))]

namespace Project.API.Universidade
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