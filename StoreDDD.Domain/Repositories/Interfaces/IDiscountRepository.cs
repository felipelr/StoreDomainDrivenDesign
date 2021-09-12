using StoreDDD.Domain.Entities;

namespace StoreDDD.Domain.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}