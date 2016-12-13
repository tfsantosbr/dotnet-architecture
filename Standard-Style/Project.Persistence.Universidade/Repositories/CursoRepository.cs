using Project.Models.Universidade.Entities;
using Project.Persistence.Core.Repositories.Base;
using Project.Persistence.Universidade.Interfaces;
using System.Data.Entity;

namespace Project.Persistence.Universidade.Repositories
{
    /// <summary>
    ///     CURSO REPOSITORY
    /// </summary>

    public class CursoRepository : RepositoryBase<Curso>, ICursoRepository<Curso>
    {
        public CursoRepository(DbContext context)
            : base(context)
        {
        }
    }
}