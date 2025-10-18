namespace Patterns.Facade.Subservices
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            
        }

        private Order CreateOrder => new Order();
    }
}