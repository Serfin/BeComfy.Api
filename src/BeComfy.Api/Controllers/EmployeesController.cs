using System.Threading.Tasks;
using BeComfy.Api.Messages.Commands.Employees;
using BeComfy.Common.Authentication;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Mvc;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace BeComfy.Api.Controllers
{
    [JwtAuthentication]
    [Route("[controller]")]
    public class EmployeesController : BaseController
    {
        public EmployeesController(IBusPublisher busPublisher, ITracer tracer)
            : base(busPublisher, tracer)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployee command)
            => await SendAsync<CreateEmployee>(command.BindId(cmd => cmd.Id), 
                resourceId: command.Id, resource: "employees");
    }
}