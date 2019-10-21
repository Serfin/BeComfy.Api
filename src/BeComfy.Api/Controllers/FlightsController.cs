using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Flights;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Mvc;
using Microsoft.AspNetCore.Mvc;
using BeComfy.Api.Services;
using System;

namespace BeComfy.Api.Controllers
{
    [Route("[controller]")]
    public class FlightsController : BaseController
    {
        private readonly IFlightsService _flightsService;

        public FlightsController(IBusPublisher busPublisher, IFlightsService flightsService)
            : base(busPublisher)
        {
            _flightsService = flightsService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateFlight command)
            => await SendAsync<CreateFlight>(command.BindId(cmd => cmd.Id),
                resourceId: command.Id, resource: "flights");

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteFlight command)
            => await SendAsync<DeleteFlight>(new DeleteFlight(command.Id));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _flightsService.GetAsync(id));
    }
}