using System.Data.Entity;
using Project.Configurations;
using Project.Models.Universidade.Entities;
using Project.Persistence.Core.Contexts.Base;

namespace Project.Persistence.Universidade.Contexts
{
    /// <summary>
    ///     UNIVERSIDADE CONTEXT
    /// </summary>
    public class UniversidadeContext : ContextBase<UniversidadeContext>
    {
        #region - CONSTRUCTORS -

        public UniversidadeContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region - MAIN METHODS -

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchemas.Universidade);
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region - DBSETS -

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Nota> Notas { get; set; }

        #endregion
    }
}