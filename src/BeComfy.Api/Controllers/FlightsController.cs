using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Flights;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Api.Controllers
{
    public class FlightsController : BaseController
    {
        public FlightsController(IBusPublisher busPublisher)
            : base(busPublisher)
        {
            
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateFlight command)
            => await SendAsync<CreateFlight>(command.BindId(cmd => cmd.Id),
                resourceId: command.Id, resource: "flights");

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteFlight command)
            => await SendAsync<DeleteFlight>(new DeleteFlight(command.Id));
    }
}