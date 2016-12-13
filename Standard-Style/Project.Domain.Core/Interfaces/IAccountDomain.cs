using Microsoft.AspNet.Identity;
using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Domain.Core.Interfaces
{
    public interface IAccountDomain : IDomainBase<Usuario>, IDomainBaseAsync<Usuario>
    {
        Task<IdentityResult> CreateAsync(Usuario user, string password);
        Task<Usuario> FindAsync(string userName, string password);

        Task<IdentityResult> ResetPasswordAsync(long userId, string token, string newPassword);

        Task<IEnumerable<Claim>> GetClaimsByUsernameAsync(string userName);

        Task<IdentityResult> ConfirmEmailAsync(long userId, string token);

        Task EnviarSolicitacaoRedefinicaoSenha(string email);
        Task EnviarSolicitacaoAtivacaoConta(Usuario usuario);
        Task EnviarNotificacaoAtivacaoConta(long id);
        Task EnviarNotificacaoRedefinicaoSenha(long id);
    }
}