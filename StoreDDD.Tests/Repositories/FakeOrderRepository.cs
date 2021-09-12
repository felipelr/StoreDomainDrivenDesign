using StoreDDD.Domain.Entities;
using StoreDDD.Domain.Repositories.Interfaces;

namespace StoreDDD.Tests.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {

        }
    }
}