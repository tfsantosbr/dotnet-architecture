using System.Data.Entity;
using Project.Models.Universidade.Entities;
using Project.Persistence.Core.Repositories.Base;
using Project.Persistence.Universidade.Interfaces;

namespace Project.Persistence.Universidade.Repositories
{
    /// <summary>
    ///     ESTUDANTE REPOSITORY
    /// </summary>

    public class EstudanteRepository : RepositoryRelationalBase<Estudante>, IEstudanteRepository
    {
        public EstudanteRepository(DbContext context)
            : base(context)
        {
        }
    }
}