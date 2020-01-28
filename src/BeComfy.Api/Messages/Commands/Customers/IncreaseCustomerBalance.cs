using System;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Messages;

namespace BeComfy.Api.Messages.Commands.Customers
{
    [MessageNamespace("customers")]
    public class IncreaseCustomerBalance : ICommand
    {
        public Guid CustomerId { get; }
        public decimal AmountToAdd { get; }

        public IncreaseCustomerBalance(Guid customerId, decimal amountToAdd)
        {
            CustomerId = customerId;
            AmountToAdd = amountToAdd;
        }
    }
}