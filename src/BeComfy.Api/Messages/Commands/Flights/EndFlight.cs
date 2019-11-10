using System;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Messages;
using Newtonsoft.Json;

namespace BeComfy.Api.Messages.Commands.Flights
{
    [MessageNamespace("flights")]
    public class EndFlight : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public EndFlight(Guid id)
        {
            Id = id;
        }
    }
}