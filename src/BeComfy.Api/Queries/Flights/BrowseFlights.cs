using BeComfy.Common.CqrsFlow;

namespace BeComfy.Api.Queries.Flights
{
    public class BrowseFlights : IQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}