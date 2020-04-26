using System;
using System.Collections.Generic;
using BeComfy.Common.Types.Enums;

namespace BeComfy.Api.Models.Airplanes
{
    public class Airplane
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string AirplaneRegistrationNumber { get; set; }
        public string AirplaneStatus { get; set; }
        public IDictionary<SeatClass, int> AvailableSeats { get; set; }
        public DateTime? NextFlight { get; set; }
        public DateTime? FlightEnd { get; set; }
    } 
}