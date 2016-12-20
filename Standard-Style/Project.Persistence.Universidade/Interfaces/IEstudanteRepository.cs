using Project.Models.Universidade.Entities;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Universidade.Interfaces
{
    /// <summary>
    ///     ESTUDANTE REPOSITORY INTERFACE
    /// </summary>

    public interface IEstudanteRepository : IRepositoryRelationalBase<Estudante>, IRepositoryRelationalBaseAsync<Estudante>
    {
    }
}
