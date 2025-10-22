namespace Patterns.Proxy.PaymentMethods
{
    public class Card : PaymentMethod
    {
        public string Number { get; private set; }
        public string ExpirationDate { get; private set; }

        public Card(float balance, string number, string expirationDate) : base(balance)
        {
            Number = number;
            ExpirationDate = expirationDate;
        }
    }
}