using System;
using System.Threading.Tasks;
using BeComfy.Api.Models.Customers;
using RestEase;

namespace BeComfy.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICustomersService
    {
        [AllowAnyStatusCode]
        [Get("customers/{id}")]
        Task<Customer> GetAsync([Path] Guid id);  
    }
}