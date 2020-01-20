using System;
using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Customers;
using BeComfy.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace BeComfy.Api.Controllers
{
    [Route("[controller]")]
    public class CustomersController : BaseController
    {
        public CustomersController(IBusPublisher busPublisher, ITracer tracer) : base(busPublisher, tracer)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomer command)
        {
            command.Id = string.IsNullOrEmpty(User?.Identity?.Name) ? Guid.Empty : Guid.Parse(User.Identity.Name);
            await SendAsync<CreateCustomer>(command, resourceId: command.Id, resource: "flights");

            return Ok();
        }
    }
}