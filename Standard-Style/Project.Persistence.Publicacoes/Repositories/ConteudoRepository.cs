using Project.Models.Publicacoes.Entities;
using Project.Persistence.Core.Repositories.Base;
using Project.Persistence.Publicacoes.Interfaces;
using System.Data.Entity;

namespace Project.Persistence.Publicacoes.Repositories
{
    /// <summary>
    ///     CONTEUDO REPOSITORY
    /// </summary>

    public class ConteudoRepository : RepositoryBase<Conteudo>, IConteudoRepository
    {
        public ConteudoRepository(DbContext context)
            : base(context)
        {
        }
    }
}