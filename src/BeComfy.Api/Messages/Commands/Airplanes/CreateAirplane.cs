using System;
using System.Collections.Generic;
using BeComfy.Common.Messages;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Types.Enums;
using Newtonsoft.Json;

namespace BeComfy.Api.Messages.Commands.Airplanes
{
    [MessageNamespace("airplanes")]
    public class CreateAirplane : ICommand
    {
        public Guid Id { get; }
        public string AirplaneRegistrationNumber { get; }
        public string Model { get; }
        public IDictionary<SeatClass, int> AvailableSeats { get; }

        [JsonConstructor]
        public CreateAirplane(Guid id, string airplaneRegistrationNumber, string model, IDictionary<SeatClass, int> availableSeats,
            DateTime introductionToTheFleet)
        {   
            Id = id;
            AirplaneRegistrationNumber = airplaneRegistrationNumber;
            Model = model;
            AvailableSeats = availableSeats;
        }
    }
}