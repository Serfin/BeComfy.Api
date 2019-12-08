using System;
using System.Collections.Generic;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Messages;
using BeComfy.Common.Types.Enums;
using Newtonsoft.Json;

namespace BeComfy.Api.Messages.Commands.Tickets
{
    [MessageNamespace("tickets")]
    public class BuyTicket : ICommand
    {
        public Guid Id { get; }
        public Guid FlightId { get; }
        public Guid CustomerId { get; }
        public IDictionary<SeatClass, int> Seats { get; }
        
        [JsonConstructor]
        public BuyTicket(Guid id, Guid flightId, Guid customerId, IDictionary<SeatClass, int> seats)
        {
            Id = id;
            FlightId = flightId;
            CustomerId = customerId;
            Seats = seats;
        }   
    }
}