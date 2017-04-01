using System.Diagnostics;
using System.Web.Http.ExceptionHandling;
using Project.Models.Core.Exceptions;

namespace Project.API.Base.Loggers
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            // Não loga se for exceção de regra de negócio
            if (context.Exception is BusinessException)
                return;

            // Loga apenas quando for uma Exception (Erro no sistema)
            Trace.TraceError(context.ExceptionContext.Exception.ToString());
        }
    }
}