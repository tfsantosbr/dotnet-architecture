using System.Data.Entity;
using Project.Models.Universidade.Entities;
using Project.Persistence.Core.Repositories.Base;
using Project.Persistence.Universidade.Interfaces;

namespace Project.Persistence.Universidade.Repositories
{
    /// <summary>
    ///     CURSO REPOSITORY
    /// </summary>

    public class CursoRepository : RepositoryRelationalBase<Curso>, ICursoRepository<Curso>
    {
        public CursoRepository(DbContext context)
            : base(context)
        {
        }
    }
}