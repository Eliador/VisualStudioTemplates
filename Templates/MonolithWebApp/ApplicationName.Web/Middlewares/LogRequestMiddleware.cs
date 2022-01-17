using ApplicationName.Core.Log;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApplicationName.Web.Middlewares
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public LogRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IApplicationLogger logger)
        {
            logger
                .Information($"Execution started [{context.Request.RouteValues["controller"]}.{context.Request.RouteValues["action"]} {context.Request.Method}]")
                .Log();

            await _next.Invoke(context);

            logger
                .Information($"Execution finished [{context.Request.RouteValues["controller"]}.{context.Request.RouteValues["action"]} {context.Request.Method}]")
                .Log();
        }
    }
}
