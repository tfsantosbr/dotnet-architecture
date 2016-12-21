using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities;

namespace Project.Domain.Core.Interfaces
{
    public interface IAccountDomain<Tkey> : IDomainBase<Usuario>, IDomainBaseAsync<Usuario>
        where Tkey : IComparable
    {
        Task<IdentityResult> CreateAsync(Usuario user, string password);
        Task<Usuario> FindAsync(string userName, string password);

        Task<IdentityResult> ResetPasswordAsync(Tkey userId, string token, string newPassword);

        Task<IEnumerable<Claim>> GetClaimsByUsernameAsync(string userName);

        Task<IdentityResult> ConfirmEmailAsync(Tkey userId, string token);

        Task EnviarSolicitacaoRedefinicaoSenha(string email);
        Task EnviarSolicitacaoAtivacaoConta(Usuario usuario);
        Task EnviarNotificacaoAtivacaoConta(Tkey id);
        Task EnviarNotificacaoRedefinicaoSenha(Tkey id);
    }
}