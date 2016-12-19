using MongoDB.Driver;
using Project.Models.Publicacoes.Entities;
using Project.Persistence.Core.Contexts.Base;

namespace Project.Persistence.Publicacoes.Contexts
{
    /// <summary>
    ///     PUBLICACOES CONTEXT
    /// </summary>
    public class PublicacoesMongoContext : MongoContextBase
    {
        #region - CONSTRUCTORS -

        public PublicacoesMongoContext()
            : base()
        {
        }

        public PublicacoesMongoContext(string connectionString)
            : base(connectionString)
        {
        }

        #endregion

        #region - COLLECTIONS -

        public IMongoCollection<Conteudo> Conteudos { get; set; }

        #endregion

        #region - MAIN METHODS -

        public override void OnModelCreating()
        {
            Conteudos = GetCollection<Conteudo>();
        }

        #endregion
    }
}