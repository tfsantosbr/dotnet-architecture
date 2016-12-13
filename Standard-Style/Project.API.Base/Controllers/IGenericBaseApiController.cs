using System;
using System.Web.Http;

namespace Project.API.Base.Controllers
{
    /// <summary>
    ///     GENERIC API CONTROLLER INTERFACE
    /// </summary>
    /// <typeparam name="TKey">Domain Model Primary Key Type</typeparam>
    /// <typeparam name="TPostModel">Post View Model</typeparam>
    /// <typeparam name="TPutModel">Put View Model</typeparam>

    public interface IGenericApiBaseController<TKey, TPostModel, TPutModel>
        where TKey : struct, IComparable
    {
        IHttpActionResult Get();

        IHttpActionResult Get(TKey id);

        IHttpActionResult Post([FromBody] TPostModel viewModel);

        IHttpActionResult Put(TKey? id, [FromBody] TPutModel viewModel);

        IHttpActionResult Delete(TKey? id);
    }
}