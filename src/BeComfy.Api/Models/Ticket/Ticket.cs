using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;

namespace BeComfy.Api.Models.Ticket
{
    public class Ticket
    {
        public Guid FlightId { get; set; }
        public Guid Owner { get; set; }
        public IDictionary<SeatClass, int> Seats { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}