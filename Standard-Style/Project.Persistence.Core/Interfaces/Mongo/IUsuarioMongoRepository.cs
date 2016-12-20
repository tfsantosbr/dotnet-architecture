using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Interfaces
{
    public interface IUsuarioMongoRepository : IRepositoryMongoBase<Usuario>, IRepositoryMongoBaseAsync<Usuario>
    {
        #region - Senha -
        string RetornaSenha(long idUsuario);
        #endregion

        #region - Claims -
        void AdicionarClaims(Claim claim, long idUsuario);
        IList<Claim> RetornarClaimsUsuario(long idUsuario);
        Task RemoveClaimAsync(long idUsuario, Claim claim);
        #endregion
    }
}