using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Api.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
            => Ok("BeComfy API Gateway");
    }
}