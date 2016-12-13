using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Project.Resources.Core.Messages;

namespace Project.API.Base.Filters
{
    public class NullParametersFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            foreach (var arg in actionContext.ActionArguments)
            {
                if (arg.Value == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                        string.Format(VALIDATION_MESSAGES.INVALID_ARGUMENT, arg.Key));

                    return;
                }
            }
        }
    }
}