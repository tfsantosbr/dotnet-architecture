using Project.Models.Core.Entities.Base;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Universidade.Interfaces
{
    /// <summary>
    ///     PROFESSOR REPOSITORY INTERFACE
    /// </summary>

    public interface IProfessorRepository<TEntity> : IRepositoryBase<TEntity>, IRepositoryBaseAsync<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
    }
}
