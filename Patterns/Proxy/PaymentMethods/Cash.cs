namespace Patterns.Proxy.PaymentMethods
{
    public class Cash : PaymentMethod
    {
        public Cash(float balance) : base(balance)
        {
        }
    }
}