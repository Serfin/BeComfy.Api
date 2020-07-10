using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Airplanes;
using BeComfy.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using BeComfy.Common.Mvc;
using BeComfy.Api.Services;
using System;
using BeComfy.Api.Queries.Airplanes;
using OpenTracing;

namespace BeComfy.Api.Controllers
{
    [Route("[controller]")]
    public class AirplanesController : BaseController
    {
        private readonly IAirplanesService _airplanesService;

        public AirplanesController(IAirplanesService airplanesService, IBusPublisher busPublisher, 
                ITracer tracer)
            : base(busPublisher, tracer)
        {
            _airplanesService = airplanesService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAirplane command)
            => await SendAsync<CreateAirplane>(command.BindId(cmd => cmd.AirplaneId),
                resourceId: command.AirplaneId, resource: "airplanes");

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _airplanesService.GetAsync(id));

        [HttpGet]
        public async Task<IActionResult> Browse([FromQuery] BrowseAirplanes query)
            => Ok(await _airplanesService.BrowseAsync(query));
    }
}