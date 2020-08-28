using ApplicationName.Core.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationName.Web.Controllers
{
    public class ViewControllerBase : Controller
    {
        protected readonly ICommandQueryDispatcher Dispatcher;

        public ViewControllerBase(ICommandQueryDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }
    }
}
