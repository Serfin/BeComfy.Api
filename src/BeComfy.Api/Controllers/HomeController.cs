using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Api.Controllers
{
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
            => Ok("BeComfy API Gateway");
    }
}