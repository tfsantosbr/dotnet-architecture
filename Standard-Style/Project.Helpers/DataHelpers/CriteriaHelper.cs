using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PagedList;

namespace Project.Helpers.DataHelpers
{
    public class CriteriaHelper<TEntity>
        where TEntity : class
    {
        #region - CONSTRUCTORS -

        /// <summary>
        ///     Initialize Helper
        /// </summary>
        public CriteriaHelper()
        {
            Filters = new List<Expression<Func<TEntity, bool>>>();
            PageSize = 25;
        }

        #endregion

        #region - AUXILIARY METHODS -

        /// <summary>
        ///     Apply filter in the query
        /// </summary>
        private void ApplyFilters(ref IQueryable<TEntity> query)
        {
            foreach (var f in Filters)
            {
                query = query.Where(f);
            }
        }

        #endregion

        #region - ATTRIBUTES -

        /// <summary>
        ///     Order Function
        /// </summary>
        private Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderFunction;

        /// <summary>
        ///     Predicate Query Filters
        /// </summary>
        private readonly List<Expression<Func<TEntity, bool>>> Filters;

        #endregion

        #region - PROPERTIES -

        /// <summary>
        ///     Page Size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Page Index
        /// </summary>
        public int? Page { get; set; }

        #endregion

        #region - MAIN METHODS -

        /// <summary>
        ///     Adds filter predicates
        /// </summary>
        /// <param name="filter">Filter predicate</param>
        public void AddFilter(Expression<Func<TEntity, bool>> filter)
        {
            Filters.Add(filter);
        }

        /// <summary>
        ///     Sets the predicate with order key
        /// </summary>
        /// <param name="predicate">Predicate with the key and order</param>
        public void AddOrderBy<TKey>(Expression<Func<TEntity, TKey>> predicate)
        {
            AddOrderBy(predicate, OrderDirection.Ascending);
        }

        /// <summary>
        ///     Sets the predicate with the order key and direction
        /// </summary>
        /// <param name="predicate">Predicate with the key and order</param>
        /// <param name="direction">Order Direction</param>
        public void AddOrderBy<TKey>(Expression<Func<TEntity, TKey>> predicate, OrderDirection direction)
        {
            if (OrderFunction == null)
            {
                switch (direction)
                {
                    case OrderDirection.Ascending:
                        OrderFunction = q => q.OrderBy(predicate);
                        break;

                    case OrderDirection.Descending:
                        OrderFunction = q => q.OrderByDescending(predicate);
                        break;

                    default:
                        OrderFunction = q => q.OrderBy(predicate);
                        break;
                }
            }
            else
            {
                var ordemFunction = OrderFunction;

                switch (direction)
                {
                    case OrderDirection.Ascending:
                        OrderFunction = q => ordemFunction(q).ThenBy(predicate);
                        break;

                    case OrderDirection.Descending:
                        OrderFunction = q => ordemFunction(q).ThenByDescending(predicate);
                        break;

                    default:
                        OrderFunction = q => ordemFunction(q).ThenBy(predicate);
                        break;
                }
            }
        }

        /// <summary>
        ///     List entries with criteria
        /// </summary>
        /// <param name="query">External Query</param>
        /// <returns>List of entries with criteria applied</returns>
        public IEnumerable<TEntity> CriteriaList(ref IQueryable<TEntity> query)
        {
            ApplyFilters(ref query);

            if (OrderFunction != null)
                query = OrderFunction(query);

            if (Page.HasValue)
                return query.ToPagedList(Page.Value, PageSize);

            return query.ToList();
        }

        /// <summary>
        ///     List entries with criteria (Async Method)
        /// </summary>
        /// <param name="query">External Query</param>
        /// <returns>List of entries with criteria applied</returns>
        public async Task<IEnumerable<TEntity>> CriteriaListAsync(IQueryable<TEntity> query)
        {
            ApplyFilters(ref query);

            if (OrderFunction != null)
                query = OrderFunction(query);

            if (Page.HasValue)
                return await query.Skip(Page.Value*PageSize).Take(PageSize).ToListAsync();

            return await query.ToListAsync();
        }

        #endregion
    }

    /// <summary>
    ///     Direction Order Type
    /// </summary>
    public enum OrderDirection
    {
        Ascending,
        Descending
    }
}