using Project.API.Base.Results;
using Project.Models.Core.Exceptions;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;

namespace Project.API.Base.Handlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is BusinessException)
            {
                context.Result = new BusinessExceptionResult
                {
                    Request = context.ExceptionContext.Request,
                    Content = context.ExceptionContext.Exception.Message
                };
            }
            else
            {
                context.Result = new ExceptionResult
                {
                    Request = context.ExceptionContext.Request,
                    Response =
                        context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                            context.Exception)
                };
            }
            ;
        }
    }
}