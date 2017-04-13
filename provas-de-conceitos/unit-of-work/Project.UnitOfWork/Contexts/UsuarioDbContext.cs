using Project.UnitOfWork.Entities;
using System.Data.Entity;

namespace Project.UnitOfWork.Contexts
{
    public class UsuarioDbContext : DbContext
    {
        #region - CONSTRUCTORS -

        public UsuarioDbContext()
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
    }
}