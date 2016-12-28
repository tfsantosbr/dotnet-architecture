using System;
using System.Collections.Generic;
using System.Web.Http;
using Project.API.Base.Filters;
using Project.API.Base.MapperAdapters;
using Project.API.Base.Models;
using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities.Base;

namespace Project.API.Base.Controllers
{
    /// <summary>
    ///     GENERIC BASE API CONTROLLER
    /// </summary>
    /// <typeparam name="TKey">Domain Model Primary Key Type</typeparam>
    /// <typeparam name="TEntity">Domain Model</typeparam>
    /// <typeparam name="TDomain">Domain</typeparam>
    /// <typeparam name="TModel">Generic View Model</typeparam>
    /// <typeparam name="TGetModel">Get Viel Model</typeparam>
    /// <typeparam name="TListItemModel">List Item View Model</typeparam>
    /// <typeparam name="TPostModel">Post View Model</typeparam>
    /// <typeparam name="TPutModel">Put View Model</typeparam>

    public abstract class GenericBaseApiController
        <TKey, TEntity, TDomain, TModel, TGetModel, TListItemModel, TPostModel, TPutModel> :
            BaseApiController<TDomain, TEntity, TKey>, IGenericApiBaseController<TKey, TPostModel, TPutModel>, IDisposable
        where TKey : IComparable
        where TEntity : IdentityEntityBase<TKey>
        where TDomain : IDomainBase<TEntity>, IDomainBaseAsync<TEntity>
        where TModel : IIdentityModelBase<TKey>
        where TGetModel : TModel
        where TListItemModel : TModel
        where TPostModel : TModel
        where TPutModel : TModel
    {
        #region - CONSTRUCTOR -
        protected GenericBaseApiController(TDomain domain, IMapperAdapter mapperAdapter)
            : base(domain, mapperAdapter)
        {
        }
        #endregion

        #region - MAIN METHODS -
        public virtual IHttpActionResult Get()
        {
            var domainModelList = Domain.List();

            var viewModelList = MapperAdapter.Adapt<IEnumerable<TEntity>, IEnumerable<TListItemModel>>(domainModelList);

            return Ok(viewModelList);
        }

        [NullParametersFilter]
        public virtual IHttpActionResult Get(TKey id)
        {
            var domainModel = Domain.Read(x => x.Id.Equals(id));

            if (domainModel == null)
                return NotFound();

            var viewModel = MapperAdapter.Adapt<TEntity, TGetModel>(domainModel);

            return Ok(viewModel);
        }

        [NullParametersFilter, ModelStateFilter]
        public virtual IHttpActionResult Post([FromBody] TPostModel viewModel)
        {
            var domainModel = MapperAdapter.Adapt<TPostModel, TEntity>(viewModel);

            Domain.Create(domainModel);
            viewModel.Id = domainModel.Id;

            return Created(Request.RequestUri, viewModel);
        }

        [NullParametersFilter, ModelStateFilter]
        public virtual IHttpActionResult Put(TKey id, [FromBody] TPutModel viewModel)
        {
            var domainModel = MapperAdapter.Adapt<TPutModel, TEntity>(viewModel);

            domainModel.Id = id;
            Domain.Update(x => x.Id.Equals(id), domainModel);

            return Ok();
        }

        [NullParametersFilter]
        public virtual IHttpActionResult Delete(TKey id)
        {
            var domainModel = Activator.CreateInstance<TEntity>();
            domainModel.Id = id;

            Domain.Delete(x => x.Id.Equals(id));

            return Ok();
        }
        #endregion
    }
}