using System;
using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Customers;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using BeComfy.Common.Authentication;
using BeComfy.Api.Services;
using BeComfy.Api.Messages.Commands.Tickets;

namespace BeComfy.Api.Controllers
{
    [JwtAuthentication]
    [Route("[controller]")]
    public class CustomersController : BaseController
    {
        private readonly ICustomersService _customersService;

        public CustomersController(IBusPublisher busPublisher, ITracer tracer,
            ICustomersService customersService) : base(busPublisher, tracer)
        {
            _customersService = customersService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomer command)
            => await SendAsync<CreateCustomer>(command.BindUserIdentity(cmd => cmd.Id, User?.Identity?.Name), 
                resourceId: command.Id, resource: "customers");

        [HttpPatch]
        public async Task<IActionResult> Post(IncreaseCustomerBalance command)
            => await SendAsync<IncreaseCustomerBalance>(command.BindUserIdentity(cmd => cmd.CustomerId, User?.Identity?.Name),
                resourceId: command.CustomerId, resource: "customers");

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _customersService.GetAsync(id));
    }
}