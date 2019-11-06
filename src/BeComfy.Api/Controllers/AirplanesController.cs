using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Airplanes;
using BeComfy.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using BeComfy.Common.Mvc;

namespace BeComfy.Api.Controllers
{
    [Route("[controller]")]
    public class AirplanesController : BaseController
    {
        public AirplanesController(IBusPublisher busPublisher)
            : base(busPublisher)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAirplane command)
            => await SendAsync<CreateAirplane>(command.BindId(cmd => cmd.Id),
                resourceId: command.Id, resource: "airplanes");
    }
}