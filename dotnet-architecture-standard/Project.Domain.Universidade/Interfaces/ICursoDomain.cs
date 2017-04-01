using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities.Base;

namespace Project.Domain.Universidade.Interfaces
{
    /// <summary>
    ///     CURSO DOMAIN INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">ENTITY DOMAIN</typeparam>

    public interface ICursoDomain<TEntity> : IDomainBase<TEntity>, IDomainBaseAsync<TEntity>
        where TEntity : EntityBase
    {
    }
}
