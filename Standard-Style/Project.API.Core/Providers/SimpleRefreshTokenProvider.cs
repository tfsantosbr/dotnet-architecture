using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.Infrastructure;
using Project.Domain.Core.Interfaces;
using Project.Helpers.Security;
using Project.Models.Core.Entities;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Project.API.Core.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            try
            {
                var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

                if (string.IsNullOrEmpty(clientid))
                    return;

                // Gera um ID unico para o RefreshToken
                var refreshTokenId = Guid.NewGuid().ToString("n");

                // Pega o tempo de expiração (em minuto) do token do contexto do Owin
                var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

                // Identifica o Browser
                var userAgent = HttpContext.Current.Request.UserAgent;
                var userBrowser = new HttpBrowserCapabilities { Capabilities = new Hashtable { { string.Empty, userAgent } } };
                var factory = new BrowserCapabilitiesFactory();
                factory.ConfigureBrowserCapabilities(new NameValueCollection(), userBrowser);
                var browser = userBrowser.Browser;

                var issuedUtc = DateTime.UtcNow;
                var expiresUtc = issuedUtc.AddMinutes(3); //issuedUtc.AddMonths(Convert.ToInt32(refreshTokenLifeTime));

                // Define os dados do RefreshToken
                var token = new RefreshToken
                {
                    Id = HashHelper.GetHash(refreshTokenId),
                    ClientId = clientid,
                    Browser = browser,
                    Subject = context.Ticket.Identity.Name,
                    IssuedUtc = issuedUtc,
                    ExpiresUtc = expiresUtc
                };

                // Define o IssuedUtc e o ExpiresUtc do ticket para determinar o quanto tempo o token vai ser válido
                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

                // Serializa o ticket para ser gravado na base de dados
                var ticketSerializer = new TicketSerializer();
                token.ProtectedTicket = ticketSerializer.Serialize(context.Ticket);

                // Grava o ticket na base de dados
                var refreshTokenDomain = DependecyConfig.Container.GetInstance<IRefreshTokenDomain>();
                var result = await refreshTokenDomain.CreateAsync(token);

                if (result)
                    context.SetToken(refreshTokenId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            // define o cabecalho da resposta do contexto do Owin com a permição de origem
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            // pega o Id do token pelo na requisição
            var hashedTokenId = HashHelper.GetHash(context.Token);

            // Identifica o Browser
            var userAgent = HttpContext.Current.Request.UserAgent;
            var userBrowser = new HttpBrowserCapabilities { Capabilities = new Hashtable { { string.Empty, userAgent } } };
            var factory = new BrowserCapabilitiesFactory();
            factory.ConfigureBrowserCapabilities(new NameValueCollection(), userBrowser);
            var browser = userBrowser.Browser;

            var refreshTokenDomain = DependecyConfig.Container.GetInstance<IRefreshTokenDomain>();
            // busca o token na base de dados pelo id
            var refreshToken = await refreshTokenDomain.ReadAsync(hashedTokenId, browser);

            // se o token for encontrado
            if (refreshToken != null)
            {
                // pega os dados do ticket para deserializar e gerar um novo ticket com 
                // as informações mapeadas do usuário que utiliza este token
                var ticketSerializer = new TicketSerializer();
                var ticket = ticketSerializer.Deserialize(refreshToken.ProtectedTicket);

                context.SetTicket(ticket);

                // remove o token da base de dados pois em nossa lógica, permitimos apenas 
                // um RefreshToken por usuário e aplicação cliente
                await refreshTokenDomain.DeleteAsync(hashedTokenId, browser);
            }
        }
    }
}