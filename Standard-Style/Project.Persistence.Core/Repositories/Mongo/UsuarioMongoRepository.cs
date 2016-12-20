using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MongoDB.Driver;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Contexts.Base;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories.Base;

namespace Project.Persistence.Core.Repositories.Mongo
{
    public class UsuarioMongoRepository : RepositoryMongoBase<Usuario>, IUsuarioMongoRepository
    {
        public UsuarioMongoRepository(MongoContextBase context)
            : base(context)
        {
        }

        #region - Senha -

        public string RetornaSenha(long idUsuario)
        {
            return Query(r => r.Id == idUsuario).SingleOrDefault()?.Senha;
        }

        #endregion

        #region - Claims -

        public void AdicionarClaims(Claim claim, long idUsuario)
        {
            var objeto = new UsuarioClaim
            {
                IdUsuario = idUsuario,
                Tipo = claim.Type,
                Valor = claim.Value,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };

            Context.GetCollection<UsuarioClaim>().InsertOne(objeto);
        }

        public IList<Claim> RetornarClaimsUsuario(long idUsuario)
        {
            List<Claim> claimsList = null;

            var registros = Context.GetCollection<UsuarioClaim>()
                .Find(r => r.IdUsuario == idUsuario)
                .ToList();

            if (registros.Count > 0)
            {
                claimsList = registros.Select(r => new Claim(r.Tipo, r.Valor)).ToList();
            }

            return claimsList;
        }

        public async Task RemoveClaimAsync(long idUsuario, Claim claim)
        {
            var resultado = await Context.GetCollection<UsuarioClaim>()
                .Find(r => r.IdUsuario == idUsuario && r.Tipo == claim.Type && r.Valor == claim.Value)
                .ToListAsync();

            resultado
                .ForEach(r => Context.GetCollection<UsuarioClaim>().FindOneAndDelete(x => x.Id == r.Id));
        }

        #endregion
    }
}