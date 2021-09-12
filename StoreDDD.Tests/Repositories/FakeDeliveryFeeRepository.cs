using StoreDDD.Domain.Repositories.Interfaces;

namespace StoreDDD.Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string zipcode)
        {
            return 10;
        }
    }
}