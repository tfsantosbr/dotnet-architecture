using System;
using System.Collections.Generic;
using Project.Models.Core.Entities.Base;

namespace Project.Domain.Core.Interfaces.Base
{
    /// <summary>
    ///     DOMAIN BASE INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public interface IDomainBase<TEntity>
        where TEntity : IEntityBase, IRowVersion
    {
        bool Create(TEntity obj);
        bool Create(IEnumerable<TEntity> objectList);

        bool Update(TEntity obj);
        bool Update(IEnumerable<TEntity> objectList);

        bool Delete(TEntity obj);
        bool Delete(IEnumerable<TEntity> objectList);
        bool Delete(Func<TEntity, bool> predicate);

        bool Active(params object[] key);
        bool Active(Func<TEntity, bool> predicate);

        bool Inactive(params object[] key);
        bool Inactive(Func<TEntity, bool> predicate);

        TEntity Read(params object[] key);

        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(Func<TEntity, bool> predicate);
    }
}