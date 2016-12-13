using Project.Models.Universidade.Entities;
using Project.Persistence.Core.Repositories.Base;
using Project.Persistence.Universidade.Interfaces;
using System.Data.Entity;

namespace Project.Persistence.Universidade.Repositories
{
    /// <summary>
    ///     PROFESSOR REPOSITORY
    /// </summary>

    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository<Professor>
    {
        public ProfessorRepository(DbContext context)
            : base(context)
        {
        }
    }
}