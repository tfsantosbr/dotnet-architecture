using Project.Models.Universidade.Entities;
using Project.Persistence.Core.Repositories.Base;
using Project.Persistence.Universidade.Interfaces;
using System.Data.Entity;

namespace Project.Persistence.Universidade.Repositories
{
    /// <summary>
    ///     ESTUDANTE REPOSITORY
    /// </summary>

    public class EstudanteRepository : RepositoryBase<Estudante>, IEstudanteRepository
    {
        public EstudanteRepository(DbContext context)
            : base(context)
        {
        }
    }
}