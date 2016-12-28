using System.Data.Entity;
using Project.Models.Universidade.Entities;
using Project.Persistence.Core.Repositories.Base;
using Project.Persistence.Universidade.Interfaces;

namespace Project.Persistence.Universidade.Repositories
{
    /// <summary>
    ///     PROFESSOR REPOSITORY
    /// </summary>

    public class ProfessorRepository : RelationalRepositoryBase<Professor>, IProfessorRepository<Professor>
    {
        public ProfessorRepository(DbContext context)
            : base(context)
        {
        }
    }
}