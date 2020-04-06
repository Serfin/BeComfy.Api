using System;
using BeComfy.Common.CqrsFlow;

namespace BeComfy.Api.Queries.Tickets
{
    public class GetTicketsForCustomer : IQuery
    {
        public Guid CustomerId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}