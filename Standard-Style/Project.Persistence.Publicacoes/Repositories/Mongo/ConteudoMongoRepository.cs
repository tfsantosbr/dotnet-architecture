using Project.Models.Publicacoes.Entities;
using Project.Persistence.Core.Contexts.Base;
using Project.Persistence.Core.Repositories.Base;
using Project.Persistence.Publicacoes.Interfaces;

namespace Project.Persistence.Publicacoes.Repositories
{
    /// <summary>
    ///     CONTEUDO REPOSITORY
    /// </summary>

    public class ConteudoMongoRepository : MongoRepositoryBase<Conteudo>, IConteudoRepository
    {
        public ConteudoMongoRepository(MongoContextBase context)
            : base(context)
        {
        }
    }
}