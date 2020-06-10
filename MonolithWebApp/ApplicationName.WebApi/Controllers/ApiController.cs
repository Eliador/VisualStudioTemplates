using ApplicationName.Core.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationName.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ApiControllerBase
    {
        public ApiController(ICommandQueryDispatcher dispatcher)
            : base(dispatcher)
        {
        }

        [HttpGet]
        public string Get()
        {
            return "Hello!";
        }
    }
}
