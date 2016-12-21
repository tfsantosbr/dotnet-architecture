using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.API.Base.Controllers
{
    /// <summary>
    ///     GENERIC ASYNCHRONOUS API CONTROLLER INTERFACE
    /// </summary>
    /// <typeparam name="TKey">Domain Model Primary Key Type</typeparam>
    /// <typeparam name="TPostModel">Post View Model</typeparam>
    /// <typeparam name="TPutModel">Put View Model</typeparam>

    public interface IGenericBaseApiControllerAsync<TKey, TPostModel, TPutModel>
        where TKey : IFormattable, IComparable
    {
        IHttpActionResult Get();

        Task<IHttpActionResult> Get(TKey id);

        Task<IHttpActionResult> Post([FromBody] TPostModel viewModel);

        Task<IHttpActionResult> Put(TKey id, [FromBody] TPutModel viewModel);

        Task<IHttpActionResult> Delete(TKey id);
    }
}