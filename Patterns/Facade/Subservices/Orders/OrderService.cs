namespace Patterns.Facade.Subservices.Orders
{
    public class OrderService
    {
        public Order CreateOrder => new ();
    }
}