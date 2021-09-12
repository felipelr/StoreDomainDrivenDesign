using StoreDDD.Domain.Entities;

namespace StoreDDD.Domain.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer Get(string document);
    }
}