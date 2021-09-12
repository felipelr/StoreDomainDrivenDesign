using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using StoreDDD.Domain.Commands.Interfaces;

namespace StoreDDD.Domain.Commands
{
    public class CreateOrderCommand : Notifiable<Notification>, ICommand
    {
        public IList<CreateOrderItemCommand> Items { get; set; }
        public string Customer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }

        public CreateOrderCommand()
        {
            Items = new List<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(IList<CreateOrderItemCommand> items, string customer, string zipCode, string promoCode)
        {
            Items = items;
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract<Object>()
                .Requires()
                .IsGreaterOrEqualsThan(Customer, 11, "Customer", "Cliente inválido")
                .IsGreaterOrEqualsThan(ZipCode, 8, "Customer", "CEP inválido")
            );
        }
    }
}