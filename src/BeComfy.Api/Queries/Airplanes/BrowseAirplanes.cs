using BeComfy.Common.CqrsFlow;

namespace BeComfy.Api.Queries.Airplanes
{
    public class BrowseAirplanes : IQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}