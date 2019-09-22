using System;
using BeComfy.Common.Messages;
using Newtonsoft.Json;

namespace BeComfy.Api.Messages.Commands.Flights
{
    [MessageNamespace("flights")]
    public class DeleteFlight
    {
        public Guid FlightId { get; set; }

        [JsonConstructor]
        public DeleteFlight(Guid flightId)
        {
            FlightId = flightId;
        }
    }
}