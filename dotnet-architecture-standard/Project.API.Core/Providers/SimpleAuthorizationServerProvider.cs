using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Project.Domain.Core.Interfaces;
using Project.Helpers.Security;
using Project.Models.Core.Entities;

namespace Project.API.Core.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        #region - MAIN METHODS -

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            // Tenta pegar o ID e o Segredo da aplicação cliente pela base64 
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                // Se não conseguir, tenta através de de codificação x-www-form-urlencoded
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            // Verifica se o ID da aplicação cliente está vazio
            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            // Busca a aplicação cliente na base de dados pelo ID
            var clientDomain = DependecyConfig.Container.GetInstance<IClientDomain>();
            var client = clientDomain.Read(x => x.Id == context.ClientId);

            // Se a aplicação cliente não estiver cadastrada
            if (client == null)
            {
                // invalida o contexto e rejeita a requisição
                context.SetError("invalid_clientId", $"Client '{context.ClientId}' is not registered in the system.");
                return Task.FromResult<object>(null);
            }

            // Se a aplicação encontrada pelo ID for do tipo NativeConfidential
            if (client.ApplicationType == ApplicationTypes.NativeConfidential)
            {
                // E se o segredo da aplicação cliente for nulo ou vazio
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    // Invalida o contexto e rejeita a requisição, pois aplicações nativas devem passar o segredo
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }

                // Se o segredo da aplicação cliente encontrada no banco de dados for diferente do segredo passado pela aplicação cliente
                if (client.Secret != HashHelper.GetHash(clientSecret))
                {
                    // Invalida o contexto e rejeita a requisição, pois o segredo deve ser o mesmo cadastrado na base de dados
                    context.SetError("invalid_clientId", "Client secret is invalid.");
                    return Task.FromResult<object>(null);
                }
            }

            // Se a aplicação cliente encontrado na base de dados se encontra inativa
            if (!client.Active)
            {
                // Invalida o contexto e rejeita a requisição, pois a aplicação precisa estar ativa para ser aceita
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            // Guarda no contexto do Owin a origem permitida e o tempo de expiração do token da aplicação cliente
            context.OwinContext.Set("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            // Valida o contexto, o que significa que a autenticação da aplicação cliente passou
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // 1. Reading the allowed origin value for this client from the Owin context, then we use this value 
            // to add the header “Access-Control-Allow-Origin” to Owin context response, by doing this and for 
            // any JavaScript application we’ll prevent using the same client id to build another JavaScript 
            // application hosted on another domain; because the origin for all requests coming from this app will be 
            // from a different domain and the back-end API will return 405 status.

            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            // 2. We’ll check the username/password for the resource owner if it is valid, and if this is the case 
            // we’ll generate set of claims for this user along with authentication properties which contains the client 
            // id and userName, those properties are needed for the next steps.

            var domain = DependecyConfig.Container.GetInstance<IAccountDomain<Guid>>();
            var usuario = await domain.FindAsync(context.UserName, context.Password);

            if (usuario == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            // 3. Retorna Claims do usuário
            var claimsCollection = await domain.GetClaimsByUsernameAsync(usuario.UserName);


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (claimsCollection != null)
                identity.AddClaims(claimsCollection);

            // MOCKING START
            identity.AddClaim(new Claim(ClaimTypes.Name, usuario.UserName));
            // MOCKING END

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {"as:client_id", context.ClientId ?? string.Empty},
                {"userName", context.UserName}
            });

            // 4. Now the access token will be generated behind the scenes when we call “context.Validated(ticket)”
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);

        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            // pega o id do cliente gravado no ticket e o id do cliente da requisição
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            // se os ID forem diferentes
            if (originalClient != currentClient)
            {
                // invalida o cliente
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return;
            }

            // adiciona ou remove novas claims setadas para este determinado usuário
            var newIdentity = new ClaimsIdentity(context.Options.AuthenticationType);


            var domain = DependecyConfig.Container.GetInstance<IAccountDomain<Guid>>();
            var claimsCollection = await domain.GetClaimsByUsernameAsync(context.Ticket.Identity.Name);
            if (claimsCollection != null)
                newIdentity.AddClaims(claimsCollection);

            // MOCKING START
            newIdentity.AddClaim(new Claim(ClaimTypes.Name, context.Ticket.Identity.Name));
            // MOCKING END

            // gera um novo ticket e valida o contexto fazendo gerar um novo token de acesso
            // e retorná-lo na resposta da requisição
            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            return Task.FromResult<object>(null);
        }

        #endregion
    }
}