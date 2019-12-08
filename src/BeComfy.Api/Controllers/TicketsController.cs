using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Flights;
using BeComfy.Api.Messages.Commands.Tickets;
using BeComfy.Common.Mvc;
using BeComfy.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace BeComfy.Api.Controllers
{
    [Route("[controller]")]
    public class TicketsController : BaseController
    {
        public TicketsController(IBusPublisher busPublisher, ITracer tracer) 
            : base(busPublisher, tracer)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(BuyTicket command)
            => await SendAsync<BuyTicket>(command.BindId(cmd => cmd.Id),
                resourceId: command.Id, resource: "tickets");

    }
}