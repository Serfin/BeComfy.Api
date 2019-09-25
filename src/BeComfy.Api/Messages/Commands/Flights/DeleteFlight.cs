using System;
using BeComfy.Common.Messages;
using Newtonsoft.Json;

namespace BeComfy.Api.Messages.Commands.Flights
{
    [MessageNamespace("flights")]
    public class DeleteFlight : ICommand
    {
        public Guid Id { get; set; }

        [JsonConstructor]
        public DeleteFlight(Guid id)
        {
            Id = id;
        }
    }
}