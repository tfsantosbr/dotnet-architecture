using Project.UnitOfWorkProject.Entities;
using System.Data.Entity;

namespace Project.Infrastructure.Context
{
    public class InfraContext : DbContext
    {
        #region - CONSTRUCTORS -

        public InfraContext()
            : base("Default")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        #region - METHODS -

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable(nameof(Usuario), "Core");
            modelBuilder.Entity<Endereco>().ToTable(nameof(Endereco), "Core");
        }

        #endregion

        #region - DBSETS -

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Paises { get; set; }

        #endregion
    }
}
