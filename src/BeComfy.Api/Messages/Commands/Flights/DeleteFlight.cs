using System;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Messages;
using Newtonsoft.Json;

namespace BeComfy.Api.Messages.Commands.Flights
{
    [MessageNamespace("flights")]
    public class DeleteFlight : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteFlight(Guid id)
        {
            Id = id;
        }
    }
}