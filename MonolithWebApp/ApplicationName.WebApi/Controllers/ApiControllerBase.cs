using ApplicationName.Core.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationName.WebApi.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ICommandQueryDispatcher Dispatcher;

        public ApiControllerBase(ICommandQueryDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }
    }
}
