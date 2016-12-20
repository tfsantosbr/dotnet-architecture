using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories.Base;

namespace Project.Persistence.Core.Repositories
{
    public class UsuarioRepository : RelationalRepositoryBase<Usuario>, IUsuarioRepository<Guid>
    {
        public UsuarioRepository(DbContext context)
            : base(context)
        {
        }

        #region - Senha -

        public string RetornaSenha(Guid idUsuario)
        {
            return Query(r => r.Id == idUsuario).SingleOrDefault()?.Senha;
        }

        #endregion

        #region - Claims -

        public void AdicionarClaims(Claim claim, Guid idUsuario)
        {
            var objeto = new UsuarioClaim
            {
                IdUsuario = idUsuario,
                Tipo = claim.Type,
                Valor = claim.Value,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };

            Context.Set<UsuarioClaim>().Add(objeto);
        }

        public IList<Claim> RetornarClaimsUsuario(Guid idUsuario)
        {
            List<Claim> claimsList = null;

            var registros = Context.Set<UsuarioClaim>()
                .Where(r => r.IdUsuario == idUsuario)
                .ToList();

            if (registros.Count > 0)
            {
                claimsList = registros.Select(r => new Claim(r.Tipo, r.Valor)).ToList();
            }

            return claimsList;
        }

        public async Task RemoveClaimAsync(Guid idUsuario, Claim claim)
        {
            var resultado = await Context.Set<UsuarioClaim>()
                .Where(r => r.IdUsuario == idUsuario && r.Tipo == claim.Type && r.Valor == claim.Value)
                .ToListAsync();

            resultado
                .ForEach(r => Context.Set<UsuarioClaim>().Remove(r));
        }

        #endregion
    }
}