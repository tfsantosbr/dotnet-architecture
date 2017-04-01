using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Project.API.Universidade
{
    public class AuthenticationConfig
    {
        public static void ConfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}