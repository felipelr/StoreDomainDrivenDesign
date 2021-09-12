using Flunt.Notifications;
using StoreDDD.Domain.Commands;
using StoreDDD.Domain.Commands.Interfaces;
using StoreDDD.Domain.Entities;
using StoreDDD.Domain.Handlers.Interfaces;
using StoreDDD.Domain.Repositories.Interfaces;
using StoreDDD.Domain.Utils;
using System.Collections.Generic;
using System.Linq;

namespace StoreDDD.Domain.Handlers
{
    public class OrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(ICustomerRepository customerRepository, IDeliveryFeeRepository deliveryFeeRepository, IDiscountRepository discountRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeRepository = deliveryFeeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Pedido inválido", command.Notifications);

            var customer = _customerRepository.Get(command.Customer);

            var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

            var discount = _discountRepository.Get(command.PromoCode);

            var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();

            var order = new Order(customer, deliveryFee, discount);
            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            AddNotifications(order.Notifications);

            if (!IsValid)
                return new GenericCommandResult(false, "Falha ao gerar pedido", Notifications);

            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
        }
    }
}