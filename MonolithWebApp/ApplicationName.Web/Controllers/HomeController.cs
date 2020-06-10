using ApplicationName.Core.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationName.Web.Controllers
{
    public class HomeController : ViewControllerBase
    {
        public HomeController(ICommandQueryDispatcher dispatcher)
            : base(dispatcher)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
