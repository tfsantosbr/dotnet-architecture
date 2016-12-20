using Project.Models.Core.Entities.Base;

namespace Project.Persistence.Core.Interfaces.Base
{
    /// <summary>
    ///    REPOSITORY BASE ASYNC INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public interface IRepositoryBaseAsync<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        #region - WRITE METHODS -



        #endregion

        #region - READ METHODS -



        #endregion
    }
}