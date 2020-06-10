using ApplicationName.Core.Log;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApplicationName.WebApi.Middlewares
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
                .Info($"Execution started [{context.Request.Method} {context.Request.Path}]")
                .Write();

            await _next.Invoke(context);

            logger
                .Info($"Execution finished [{context.Request.Method} {context.Request.Path}]")
                .Write();
        }
    }
}
