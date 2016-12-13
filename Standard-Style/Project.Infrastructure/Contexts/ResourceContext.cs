using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Project.Configurations;
using Project.Models.Core.Entities;
using Project.Models.Publicacoes.Entities;
using Project.Models.Universidade.Entities;

namespace Project.Infrastructure.Contexts
{
    /// <summary>
    ///     DATA INFRASTRUCTURE FULL RESOURCE CONTEXT
    /// </summary>
    public class ResourceContext : DbContext
    {
        #region - CONSTRUCTORS -

        public ResourceContext()
            : base(ConnectionStrings.ResourceConnection)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        #region - METHODS -

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region - Core -

            modelBuilder.Entity<Client>().ToTable(nameof(Client), DefaultSchemas.Core);
            modelBuilder.Entity<RefreshToken>().ToTable(nameof(RefreshToken), DefaultSchemas.Core);
            modelBuilder.Entity<Role>().ToTable(nameof(Role), DefaultSchemas.Core);
            modelBuilder.Entity<Usuario>().ToTable(nameof(Usuario), DefaultSchemas.Core);
            modelBuilder.Entity<UsuarioClaim>().ToTable(nameof(UsuarioClaim), DefaultSchemas.Core);
            modelBuilder.Entity<UsuarioRole>().ToTable(nameof(UsuarioRole), DefaultSchemas.Core);

            #endregion

            #region - Universidade -

            modelBuilder.Entity<Curso>().ToTable(nameof(Curso), DefaultSchemas.Universidade);
            modelBuilder.Entity<Estudante>().ToTable(nameof(Estudante), DefaultSchemas.Universidade);
            modelBuilder.Entity<Matricula>().ToTable(nameof(Matricula), DefaultSchemas.Universidade);
            modelBuilder.Entity<Nota>().ToTable(nameof(Nota), DefaultSchemas.Universidade);
            modelBuilder.Entity<Professor>().ToTable(nameof(Professor), DefaultSchemas.Universidade);

            #endregion

            #region - Publicacoes -

            modelBuilder.Entity<Conteudo>().ToTable(nameof(Conteudo), DefaultSchemas.Publicacoes);

            #endregion

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }

        #endregion

        #region - DBSETS -

        #region - Core -

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioClaim> UsuarioClaims { get; set; }
        public DbSet<UsuarioRole> UsuarioRoles { get; set; }

        #endregion

        #region - Universidade -

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        #endregion

        #region - Publicacoes -

        public DbSet<Conteudo> Conteudos { get; set; }

        #endregion

        #endregion
    }
}