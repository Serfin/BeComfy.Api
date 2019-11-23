using System;
using BeComfy.Common.CqrsFlow;

namespace BeComfy.Api.Queries.Airplanes
{
    public class GetAirplane : IQuery
    {
        public Guid Id { get; set; }
    }
}