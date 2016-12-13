using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.API.Base.Validations
{
    public class ExceptionResult : IHttpActionResult
    {
        public ExceptionResult()
        {
            Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public HttpRequestMessage Request { get; set; }
        public string Content { get; set; }
        public HttpResponseMessage Response { get; set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            Response.Content = new StringContent(Content);
            Response.RequestMessage = Request;

            return Task.FromResult(Response);
        }
    }
}