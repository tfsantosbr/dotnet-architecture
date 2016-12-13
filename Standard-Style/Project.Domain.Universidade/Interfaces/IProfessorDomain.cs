using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities.Base;

namespace Project.Domain.Universidade.Interfaces
{
    /// <summary>
    ///     PROFESSOR DOMAIN INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">ENTITY DOMAIN</typeparam>

    public interface IProfessorDomain<TEntity> : IDomainBase<TEntity>, IDomainBaseAsync<TEntity>
        where TEntity : EntityBase
    {
    }
}