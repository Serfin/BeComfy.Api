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
        public Guid CustomerId { get; }
        public Guid FlightId { get; }
        public IDictionary<SeatClass, int> Seats { get; }
        
        [JsonConstructor]
        public BuyTicket(Guid id, Guid customerId, Guid flightId, IDictionary<SeatClass, int> seats)
        {
            Id = id;
            CustomerId = customerId;
            FlightId = flightId;
            Seats = seats;
        }   
    }
}