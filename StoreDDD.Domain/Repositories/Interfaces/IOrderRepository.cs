using StoreDDD.Domain.Entities;

namespace StoreDDD.Domain.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}