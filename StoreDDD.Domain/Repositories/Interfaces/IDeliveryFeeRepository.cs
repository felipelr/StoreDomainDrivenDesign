namespace StoreDDD.Domain.Repositories.Interfaces
{
    public interface IDeliveryFeeRepository
    {
        decimal Get(string zipcode);
    }
}