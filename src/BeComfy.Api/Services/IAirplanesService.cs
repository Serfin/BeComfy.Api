using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Api.Models.Airplanes;
using BeComfy.Api.Queries.Airplanes;
using RestEase;

namespace BeComfy.Api.Services
{
    public interface IAirplanesService
    {
        [AllowAnyStatusCode]
        [Get("airplanes/{id}")]
        Task<Airplane> Get([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("airplanes")]
        Task<IEnumerable<Airplane>> BrowseAsync([Query] BrowseAirplanes query);
    }
}