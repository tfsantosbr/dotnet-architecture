using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Project.Configurations;
using Project.Domain.Core.Domains.Base;
using Project.Domain.Core.Interfaces;
using Project.Helpers.Email;
using Project.Models.Core.Entities;
using Project.Models.Core.Exceptions;
using Project.Persistence.Core.Interfaces;
using Project.Resources.Core.Messages;
using Project.Resources.Core.Templates;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Domain.Core.Domains
{
    public class AccountDomain : DomainBase<Usuario, IUsuarioRepository>, IAccountDomain
    {
        #region - PROPERTIES -
        private readonly UserManager<Usuario, long> _userManager;
        #endregion

        #region - CONSTRUCTORS -

        public AccountDomain(UserManager<Usuario, long> userManager, IUsuarioRepository repository)
            : base(repository)
        {
            _userManager = userManager;

            var provider = new DpapiDataProtectionProvider("YourAppName");
            _userManager.UserTokenProvider = new DataProtectorTokenProvider<Usuario, long>(provider.Create("EmailConfirmation"));
        }

        #endregion

        #region - MAIN METHODS -

        public override async Task<bool> CreateAsync(Usuario user)
        {
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded;
        }

        public async Task<IdentityResult> CreateAsync(Usuario user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<Usuario> FindAsync(string userName, string password)
        {
            return await _userManager.FindAsync(userName, password);

        }

        public async Task<IdentityResult> ResetPasswordAsync(long userId, string token, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(userId, token, newPassword);
        }

        public async Task<IEnumerable<Claim>> GetClaimsByUsernameAsync(string userName)
        {
            var usuario = await _userManager.FindByNameAsync(userName);

            if (usuario == null)
                return null;

            return await _userManager.GetClaimsAsync(usuario.Id);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(long userId, string token)
        {
            return await _userManager.ConfirmEmailAsync(userId, token);
        }

        public async Task EnviarSolicitacaoRedefinicaoSenha(string email)
        {
            var usuario = await _userManager.FindByNameAsync(email);

            if (usuario == null || !usuario.EmailConfirmed)
                throw new BusinessException(IDENTITY_MESSAGES.INVALID_USER);

            var token = await _userManager.GeneratePasswordResetTokenAsync(usuario.Id);
            token = WebUtility.UrlEncode(token);

            var urlResetPassword = string.Format(UrlSettings.URL_ACCOUNT_RESET_PASSWORD, usuario.Id, token);

            var emailTitulo =
                $"{GlobalSettings.APPLICATION_NAME}: {EMAIL_MESSAGES.ACCOUNT_RESET_PASSWORD_SOLICITATION_TITLE}";
            var emailMensagem =
                EMAIL_MESSAGES.ACCOUNT_RESET_PASSWORD_SOLICITATION_MESSAGE.Replace("{URL_RESET_PASSWORD}",
                    urlResetPassword);
            var emailTemplate = EMAIL_TEMPLATES.EMAIL_NOTIFICATION;
            var emailCorpo = emailTemplate
                .Replace("{TITLE}", emailTitulo)
                .Replace("{MESSAGE}", emailMensagem);

            var emailMessage = new EmailMessage();
            emailMessage.To.Add(usuario.Email);
            emailMessage.Subject = emailTitulo;
            emailMessage.Body = emailCorpo;

            var emailService = new EmailHelper();
            await emailService.SendAsync(emailMessage);
        }

        public async Task EnviarSolicitacaoAtivacaoConta(Usuario usuario)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario.Id);
            token = WebUtility.UrlEncode(token);

            var urlAccountConfirmation = string.Format(UrlSettings.URL_ACCOUNT_CONFIRMATION, usuario.Id, token);

            var emailTitulo = $"{GlobalSettings.APPLICATION_NAME}: {EMAIL_MESSAGES.ACCOUNT_CONFIRMATION_TITLE}";
            var emailMensagem = EMAIL_MESSAGES.ACCOUNT_CONFIRMATION_MESSAGE.Replace("{URL_ACCOUNT_CONFIRMATION}",
                urlAccountConfirmation);
            var emailTemplate = EMAIL_TEMPLATES.EMAIL_NOTIFICATION;
            var emailCorpo = emailTemplate
                .Replace("{TITLE}", emailTitulo)
                .Replace("{MESSAGE}", emailMensagem);

            var emailMessage = new EmailMessage();
            emailMessage.To.Add(usuario.Email);
            emailMessage.Subject = emailTitulo;
            emailMessage.Body = emailCorpo;

            var emailService = new EmailHelper();
            await emailService.SendAsync(emailMessage);
        }

        public async Task EnviarNotificacaoAtivacaoConta(long id)
        {
            var usuario = await _userManager.FindByIdAsync(id);

            if (usuario == null)
                throw new BusinessException(IDENTITY_MESSAGES.INVALID_USER);

            var emailTitulo =
                $"{GlobalSettings.APPLICATION_NAME}: {EMAIL_MESSAGES.ACCOUNT_CONFIRMATION_NOTIFICATION_TITLE}";
            var emailMensagem = EMAIL_MESSAGES.ACCOUNT_CONFIRMATION_NOTIFICATION_MESSAGE;
            var emailTemplate = EMAIL_TEMPLATES.EMAIL_NOTIFICATION;
            var emailCorpo = emailTemplate
                .Replace("{TITLE}", emailTitulo)
                .Replace("{MESSAGE}", emailMensagem);

            var emailMessage = new EmailMessage();
            emailMessage.To.Add(usuario.Email);
            emailMessage.Subject = emailTitulo;
            emailMessage.Body = emailCorpo;

            var emailService = new EmailHelper();
            await emailService.SendAsync(emailMessage);
        }

        public async Task EnviarNotificacaoRedefinicaoSenha(long id)
        {
            var usuario = await _userManager.FindByIdAsync(id);

            if (usuario == null)
                throw new BusinessException(IDENTITY_MESSAGES.INVALID_USER);

            var token = await _userManager.GeneratePasswordResetTokenAsync(usuario.Id);
            token = WebUtility.UrlEncode(token);

            var urlResetPassword = string.Format(UrlSettings.URL_ACCOUNT_RESET_PASSWORD, usuario.Id, token);

            var emailTitulo =
                $"{GlobalSettings.APPLICATION_NAME}: {EMAIL_MESSAGES.ACCOUNT_RESET_PASSWORD_NOTIFICATION_TITLE}";
            var emailMensagem =
                EMAIL_MESSAGES.ACCOUNT_RESET_PASSWORD_NOTIFICATION_MESSAGE.Replace("{URL_RESET_PASSWORD}",
                    urlResetPassword);
            var emailTemplate = EMAIL_TEMPLATES.EMAIL_NOTIFICATION;
            var emailCorpo = emailTemplate
                .Replace("{TITLE}", emailTitulo)
                .Replace("{MESSAGE}", emailMensagem);

            var emailMessage = new EmailMessage();
            emailMessage.To.Add(usuario.Email);
            emailMessage.Subject = emailTitulo;
            emailMessage.Body = emailCorpo;

            var emailService = new EmailHelper();
            await emailService.SendAsync(emailMessage);
        }

        #endregion

        //#region - AUXILIARY METHODS -

        //#region - DISPOSE -

        //~AccountDomain()
        //{
        //    Dispose(false);
        //}

        //public override void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (!disposing) return;
        //    _userManager?.Dispose();
        //}

        //#endregion

        //#endregion
    }
}