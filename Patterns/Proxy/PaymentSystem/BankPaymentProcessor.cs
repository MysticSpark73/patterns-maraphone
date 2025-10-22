using System;
using Patterns.Proxy.PaymentMethods;

namespace Patterns.Proxy.PaymentSystem
{
    public class BankPaymentProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(PaymentMethod paymentMethod, float amount)
        {
            paymentMethod.Pay(amount);
            Console.Out.WriteLine($"Operation Successful! Current balance : {paymentMethod.Balance}");
            return true;
        }
    }
}