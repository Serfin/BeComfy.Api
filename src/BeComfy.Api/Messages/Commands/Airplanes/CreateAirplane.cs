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
        public string Model { get; }
        public IDictionary<SeatClass, int> AvailableSeats { get; }
        public DateTime IntroductionToTheFleet { get; }

        [JsonConstructor]
        public CreateAirplane(Guid id, string model, IDictionary<SeatClass, int> availableSeats,
            DateTime introductionToTheFleet)
        {   
            Id = id;
            Model = model;
            AvailableSeats = availableSeats;
        }
    }
}