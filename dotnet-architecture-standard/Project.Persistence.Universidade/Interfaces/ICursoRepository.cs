using Project.Models.Core.Entities.Base;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Universidade.Interfaces
{
    /// <summary>
    ///     CURSO REPOSITORY INTERFACE
    /// </summary>

    public interface ICursoRepository<TEntity> : IRepositoryBase<TEntity>, IRepositoryBaseAsync<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
    }
}
