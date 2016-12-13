using System.Data.Entity;
using Project.Configurations;
using Project.Models.Publicacoes.Entities;
using Project.Persistence.Core.Contexts.Base;

namespace Project.Persistence.Publicacoes.Contexts
{
    /// <summary>
    ///     PUBLICACOES CONTEXT
    /// </summary>
    public class PublicacoesContext : BaseContext<PublicacoesContext>
    {
        #region - CONSTRUCTORS -

        public PublicacoesContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region - DBSETS -

        public DbSet<Conteudo> Conteudos { get; set; }

        #endregion

        #region - MAIN METHODS -

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchemas.Publicacoes);
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}