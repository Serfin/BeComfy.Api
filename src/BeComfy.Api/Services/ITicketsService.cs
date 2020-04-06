using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Api.Models.Ticket;
using BeComfy.Api.Queries.Tickets;
using RestEase;

namespace BeComfy.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ITicketsService
    {
        [AllowAnyStatusCode]
        [Get("tickets")]
        Task<IEnumerable<Ticket>> BrowseAsync([Query] GetTicketsForCustomer query);
    }
}