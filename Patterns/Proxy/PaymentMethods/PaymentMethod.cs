namespace Patterns.Proxy.PaymentMethods
{
    public abstract class PaymentMethod
    {
        public float Balance => _balance;
        
        private float _balance;

        protected PaymentMethod(float balance)
        {
            _balance = balance;
        }

        public void Pay(float value) => _balance -= value;
    }
}