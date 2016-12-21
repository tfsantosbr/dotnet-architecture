using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Interfaces
{
    public interface IUsuarioRepository<TKey> : IRepositoryBase<Usuario>, IRepositoryBaseAsync<Usuario>
        where TKey : struct, IComparable
    {
        #region - Senha -
        string RetornaSenha(TKey idUsuario);
        #endregion

        #region - Claims -
        Task AddClaimAsync(Claim claim, TKey idUsuario);
        IList<Claim> GetClaimsUsuario(TKey idUsuario);
        Task RemoveClaimAsync(TKey idUsuario, Claim claim);
        #endregion
    }
}