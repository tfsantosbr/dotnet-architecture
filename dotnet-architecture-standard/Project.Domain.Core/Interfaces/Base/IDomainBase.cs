using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Project.Models.Core.Entities.Base;

namespace Project.Domain.Core.Interfaces.Base
{
    /// <summary>
    ///     DOMAIN BASE INTERFACE
    /// </summary>
    /// <typeparam name="TEntity">EntityBase Type</typeparam>

    public interface IDomainBase<TEntity>
        where TEntity : EntityBase
    {
        void Create(TEntity obj);
        void Create(IEnumerable<TEntity> objectList);

        void Update(Expression<Func<TEntity, bool>> predicate, TEntity obj);
        void Update(IEnumerable<TEntity> objectList);

        void Delete(IEnumerable<TEntity> objectList);
        void Delete(Expression<Func<TEntity, bool>> predicate);

        void Active(Expression<Func<TEntity, bool>> predicate);

        void Inactive(Expression<Func<TEntity, bool>> predicate);

        TEntity Read(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> List();
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);
    }
}