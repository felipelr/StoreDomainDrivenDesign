using StoreDDD.Domain.Repositories.Interfaces;
using StoreDDD.Domain.Entities;

namespace StoreDDD.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678910")
                return new Customer("Felipe Lima", "felipe@gmail.com");

            return null;
        }
    }
}