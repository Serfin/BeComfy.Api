using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;

namespace BeComfy.Api.Models.Flights
{
    public class Flight
    {
        public Guid Id { get; private set; }
        public Guid PlaneId { get; private set; }
        public IDictionary<SeatClass, int> AvailableSeats { get; private set; }
        public Guid StartAirport { get; private set; }
        public IEnumerable<Guid> TransferAirports { get; private set; }
        public Guid EndAirport { get; private set; }
        public FlightType FlightType { get; private set; }
        public decimal Price { get; private set; }
        public DateTime FlightDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}