namespace StoreDDD.Domain.Enums
{
    public enum EOrderStatus
    {
        WaitingPayment = 1,
        WaitingDelivery = 2,
        Canceled = 3,
        Concluded = 4
    }
}