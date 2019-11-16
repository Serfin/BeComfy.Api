using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Flights;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Mvc;
using Microsoft.AspNetCore.Mvc;
using BeComfy.Api.Services;
using System;
using BeComfy.Api.Queries.Flights;

namespace BeComfy.Api.Controllers
{
    [ApiController]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync<DeleteFlight>(new DeleteFlight(id));

        [HttpPatch("{id}")]
        public async Task<IActionResult> End(Guid id)
            => await SendAsync<EndFlight>(new EndFlight(id));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _flightsService.GetAsync(id));

        [HttpGet]
        public async Task<IActionResult> Browse([FromQuery] BrowseFlights query)
            => Ok(await _flightsService.BrowseAsync(query));
    }
}