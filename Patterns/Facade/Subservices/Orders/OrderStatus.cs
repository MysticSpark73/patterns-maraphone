namespace Patterns.Facade.Subservices.Orders
{
    public enum OrderStatus : byte
    {
        Created,
        Checkout,
        PaymentComplete,
        WaitingDelivery,
        Delivering,
        Delivered,
        Completed,
        Returned
    }
}