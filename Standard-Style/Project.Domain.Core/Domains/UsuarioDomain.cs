using Microsoft.AspNet.Identity;
using Project.Domain.Core.Domains.Base;
using Project.Domain.Core.Interfaces;
using Project.Models.Core.Entities;
using Project.Models.Core.Exceptions;
using Project.Persistence.Core.Interfaces;
using Project.Resources.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Domain.Core.Domains
{
    public class UsuarioDomain : DomainBase<Usuario, IUsuarioRepository>,
        IUsuarioDomain,
        IUserPasswordStore<Usuario, long>,
        IUserSecurityStampStore<Usuario, long>,
        IUserEmailStore<Usuario, long>,
        IUserClaimStore<Usuario, long>,
        IUserLoginStore<Usuario, long>,
        IUserRoleStore<Usuario, long>
    {
        #region - CONSTRUCTORS -

        public UsuarioDomain(IUsuarioRepository repository)
            : base(repository)
        {
        }

        #endregion

        #region - MAIN METHODS -

        #region - Usuario -

        public new async Task CreateAsync(Usuario usuario)
        {
            await base.CreateAsync(usuario);
        }

        public new async Task DeleteAsync(Usuario usuario)
        {
            await base.DeleteAsync(usuario);
        }

        public Task<Usuario> FindByIdAsync(long id)
        {
            var usuario = Read(id);

            if (usuario == null)
                throw new BusinessException(IDENTITY_MESSAGES.INVALID_USER);

            return System.Threading.Tasks.Task.FromResult(usuario);
        }

        public Task<Usuario> FindByNameAsync(string userName)
        {
            var usuario = Repository.Query(r => r.UserName == userName).FirstOrDefault();

            if (usuario != null && VisibleRecordses == VisibleRecords.Active && usuario.ExclusionDate != null)
                throw new InactiveRecordException();

            return System.Threading.Tasks.Task.FromResult(usuario);
        }

        public new async Task UpdateAsync(Usuario usuario)
        {
            await base.UpdateAsync(usuario);
        }

        #endregion

        #region - Senha -

        public Task<string> GetPasswordHashAsync(Usuario usuario)
        {
            return System.Threading.Tasks.Task.FromResult(Repository.RetornaSenha(usuario.Id));
        }

        public Task<bool> HasPasswordAsync(Usuario usuario)
        {
            return System.Threading.Tasks.Task.FromResult(Repository.RetornaSenha(usuario.Id) != null);
        }

        public Task SetPasswordHashAsync(Usuario usuario, string senhaHash)
        {
            usuario.Senha = senhaHash;

            return System.Threading.Tasks.Task.FromResult<object>(null);
        }

        #endregion

        #region - SecurityStamp -

        public Task<string> GetSecurityStampAsync(Usuario usuario)
        {
            return System.Threading.Tasks.Task.FromResult(usuario.SecurityStamp);
        }

        public Task SetSecurityStampAsync(Usuario usuario, string stamp)
        {
            usuario.SecurityStamp = stamp;

            return System.Threading.Tasks.Task.FromResult<object>(null);
        }

        #endregion

        #region - E-Mail -

        public Task<Usuario> FindByEmailAsync(string email)
        {
            var usuario = Repository.Query(r => r.Email == email).FirstOrDefault();

            if (usuario != null && VisibleRecordses == VisibleRecords.Active && usuario.ExclusionDate != null)
                throw new InactiveRecordException();

            return Task.FromResult(usuario);
        }

        public Task<string> GetEmailAsync(Usuario usuario)
        {
            return Task.FromResult(usuario.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(Usuario usuario)
        {
            return Task.FromResult(usuario.EmailConfirmed);
        }

        public async Task SetEmailAsync(Usuario usuario, string email)
        {
            usuario.Email = email;
            await base.UpdateAsync(usuario);
        }

        public async Task SetEmailConfirmedAsync(Usuario usuario, bool confirmed)
        {
            if (usuario.EmailConfirmed)
                throw new BusinessException(IDENTITY_MESSAGES.ALREADY_CONFIRMED_ACCOUNT);

            usuario.EmailConfirmed = confirmed;
            await base.UpdateAsync(usuario);
        }

        #endregion

        #region - Claims -

        public Task<IList<Claim>> GetClaimsAsync(Usuario usuario)
        {
            return Task.FromResult(Repository.RetornarClaimsUsuario(usuario.Id));
        }

        public async Task RemoveClaimAsync(Usuario usuario, Claim claim)
        {
            await Repository.RemoveClaimAsync(usuario.Id, claim);
        }

        public async Task AddClaimAsync(Usuario usuario, Claim claim)
        {
            Repository.AdicionarClaims(claim, usuario.Id);
            await Repository.SaveAsync();
        }

        #endregion

        #region - Login -

        public Task AddLoginAsync(Usuario user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(Usuario user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(Usuario user)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region - Perfis -

        public Task AddToRoleAsync(Usuario user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(Usuario user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(Usuario user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(Usuario user, string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region - AUXILIARY METHODS -

        #region - DISPOSE -

        ~UsuarioDomain()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
        }

        #endregion

        #endregion
    }
}