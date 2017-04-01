using Project.Domain.Core.Interfaces.Base;
using Project.Models.Universidade.Entities;

namespace Project.Domain.Universidade.Interfaces
{
    /// <summary>
    ///     ESTUDANTE DOMAIN INTERFACE
    /// </summary>

    public interface IEstudanteDomain : IDomainBase<Estudante>, IDomainBaseAsync<Estudante>
    {
    }
}
