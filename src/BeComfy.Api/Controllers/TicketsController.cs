using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Flights;
using BeComfy.Api.Messages.Commands.Tickets;
using BeComfy.Api.Queries.Tickets;
using BeComfy.Api.Services;
using BeComfy.Common.Authentication;
using BeComfy.Common.Mvc;
using BeComfy.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace BeComfy.Api.Controllers
{
    [JwtAuthentication]
    [Route("[controller]")]
    public class TicketsController : BaseController
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(IBusPublisher busPublisher, ITracer tracer,
            ITicketsService ticketsService) 
            : base(busPublisher, tracer)
        {
            _ticketsService = ticketsService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BuyTicket command)
            => await SendAsync<BuyTicket>(command.BindId(cmd => cmd.Id)
                .BindUserIdentity(cmd => cmd.CustomerId, User?.Identity?.Name),
                    resourceId: command.Id, resource: "tickets");

        [HttpGet]
        public async Task<IActionResult> Browse([FromQuery] GetTicketsForCustomer query)
            => Ok(await _ticketsService.BrowseAsync(query));
    }
}