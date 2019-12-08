using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Types.Enums;

namespace BeComfy.Api.Queries.Airplanes
{
    public class BrowseAirplanes : IQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public AirplaneStatus Status { get; set; }
    }
}