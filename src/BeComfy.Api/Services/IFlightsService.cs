using System;
using System.Threading.Tasks;
using BeComfy.Api.Models.Flights;
using RestEase;

namespace BeComfy.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IFlightsService
    {
        [AllowAnyStatusCode]
        [Get("flights/{id}")]
        Task<Flight> GetAsync([Path] Guid id);
    }
}