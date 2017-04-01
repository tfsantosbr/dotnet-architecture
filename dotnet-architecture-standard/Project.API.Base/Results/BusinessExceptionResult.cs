using System.Net;
using System.Net.Http;

namespace Project.API.Base.Results
{
    public class BusinessExceptionResult : ExceptionResult
    {
        public BusinessExceptionResult()
        {
            Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}