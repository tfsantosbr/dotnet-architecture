using System.Data.Entity;
using Project.Configurations;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Contexts.Base;

namespace Project.Persistence.Core.Contexts
{
    public class CoreContext : ContextBase<CoreContext>
    {
        #region - CONSTRUCTORS -

        public CoreContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region - MAIN METHODS -

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchemas.Core);
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region - DBSETS -

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioClaim> UsuarioClaims { get; set; }
        public DbSet<UsuarioRole> UsuarioRoles { get; set; }

        #endregion
    }
}