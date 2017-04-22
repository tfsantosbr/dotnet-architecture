using Project.UnitOfWorkProject.Entities;
using System.Data.Entity;
using System.Diagnostics;

namespace Project.UnitOfWorkProject.Contexts
{
    public class UsuarioDbContext : DbContext
    {
        #region - CONSTRUCTORS -

        public UsuarioDbContext()
            : base("Default")
        {
            Debug.Print("[Contexto] Started...");

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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Debug.Print("[Contexto] Disposed!");

            base.Dispose(disposing);
        }
    }
}