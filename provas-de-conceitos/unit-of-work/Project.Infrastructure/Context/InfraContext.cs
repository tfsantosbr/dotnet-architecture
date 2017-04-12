using Project.UnitOfWork.Entities;
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
        }

        #endregion

        #region - DBSETS -

        public DbSet<Usuario> Usuarios { get; set; }

        #endregion
    }
}
