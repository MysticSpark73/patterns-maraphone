using Patterns.Common;
using Patterns.Proxy.PaymentMethods;
using Patterns.Proxy.PaymentSystem;

namespace Patterns.Proxy
{
    public class ProxyMain : IProgram
    {
        private BankPaymentProcessor _bankPaymentProcessor;
        private ProxyPaymentProcessor _paymentProcessor;

        private Cash _cash;
        private Card _card1;
        private Card _card2;
        
        
        public void Run(object[]? args = null)
        {
            CreatePaymentProcessor();
            CreatePaymentMethods();
            PerformOperations();
        }

        private void CreatePaymentProcessor()
        {
            _bankPaymentProcessor = new BankPaymentProcessor();
            _paymentProcessor = new ProxyPaymentProcessor(_bankPaymentProcessor);
        }

        private void CreatePaymentMethods()
        {
            _cash = new Cash(1000);
            _card1 = new Card(6700, "4992.7398.717", "19/28");
            _card2 = new Card(666, "4992 7398 716", "04/30");
        }

        private void PerformOperations()
        {
            _paymentProcessor.ProcessPayment(_card1, 200);
            _paymentProcessor.ProcessPayment(_card2, 1000);
            _paymentProcessor.ProcessPayment(_card2, 597);
            _paymentProcessor.ProcessPayment(_cash, 9000);
            _paymentProcessor.ProcessPayment(_cash, 933);
        }
    }
}