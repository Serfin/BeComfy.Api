using System;
using System.Linq;
using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace BeComfy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private static readonly string AcceptLanguageHeader = "accept-language";
        private static readonly string DefaultCulture = "en-us";
        private readonly IBusPublisher _busPublisher;
        private readonly ITracer _tracer;

        public BaseController(IBusPublisher busPublisher, ITracer tracer)
        {
            _busPublisher = busPublisher;
            _tracer = tracer;
        }

        protected async Task<IActionResult> SendAsync<T>(T command, 
            Guid? resourceId = null, string resource = "") where T : ICommand 
        {
            var context = GetContext<T>(resourceId, resource);
            await _busPublisher.SendAsync(command, context);

            return Accepted(context);
        }

        protected ICorrelationContext GetContext<T>(Guid? resourceId = null, string resource = "") where T : ICommand
        {
            if (!string.IsNullOrWhiteSpace(resource))
            {
                resource = $"{resource}/{resourceId}";
            }

            return CorrelationContext.Create<T>(Guid.NewGuid(), UserId, resourceId ?? Guid.Empty, 
               HttpContext.TraceIdentifier, HttpContext.Connection.Id, _tracer.ActiveSpan.Context.ToString(),
                Request.Path.ToString(), Culture, resource);
        }

        protected Guid UserId
            => string.IsNullOrWhiteSpace(User?.Identity?.Name) ? 
                Guid.Empty : 
                Guid.Parse(User.Identity.Name);

        protected string Culture 
            => Request.Headers.ContainsKey(AcceptLanguageHeader) ? 
                    Request.Headers[AcceptLanguageHeader].First().ToLowerInvariant() :
                    DefaultCulture;
    }
}