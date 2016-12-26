using System;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Project.API.Base.MapperAdapters;
using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities.Base;

namespace Project.API.Base.Controllers
{
    /// <summary>
    ///     BASE API CONTROLLER
    /// </summary>

    public abstract class BaseApiController<TDomain, TEntity, TKey> : ApiController
        where TKey : IComparable
        where TEntity : IdentityEntityBase<TKey>
        where TDomain : IDomainBase<TKey, TEntity>, IDomainBaseAsync<TKey, TEntity>
    {
        #region - PROPERTIES -
        protected readonly IMapperAdapter MapperAdapter;
        protected readonly TDomain Domain;
        #endregion

        #region - CONSTRUCTORS -

        protected BaseApiController(TDomain domain, IMapperAdapter mapperAdapter)
        {
            MapperAdapter = mapperAdapter;
            Domain = domain;
        }

        #endregion

        #region - AUXILIARY METHODS -

        #region - RESULTS -

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
                return InternalServerError();

            if (result.Succeeded)
                return null;

            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            if (ModelState.IsValid)
                return BadRequest();

            return BadRequest(ModelState);
        }

        #endregion

        #endregion
    }
}