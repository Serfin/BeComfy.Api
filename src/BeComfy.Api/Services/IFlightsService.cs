using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Api.Models.Flights;
using BeComfy.Api.Queries.Flights;
using RestEase;

namespace BeComfy.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IFlightsService
    {
        [AllowAnyStatusCode]
        [Get("flights/{id}")]
        Task<Flight> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("flights")]
        Task<IEnumerable<Flight>> BrowseAsync([Query] BrowseFlights query);
    }
}