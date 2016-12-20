using System;
using Project.Models.Core.Entities.Base;

namespace Project.Persistence.Core.Repositories.Base
{
    /// <summary>
    ///     REPOSITORY BASE CLASS
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public abstract class RepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        public virtual void Create(TEntity obj)
        {
            obj.CreationDate = DateTime.Now;
            obj.ModificationDate = DateTime.Now;
        }

        public void Update(TEntity obj)
        {
            obj.ModificationDate = DateTime.Now;
        }
    }
}