using System;
using System.Collections.Generic;
using Patterns.Proxy.PaymentMethods;
using Patterns.Proxy.PaymentOperationProviders;

namespace Patterns.Proxy.PaymentSystem
{
    public class ProxyPaymentProcessor : IPaymentProcessor
    {
        private readonly Dictionary<Type, IPaymentOperationValidatorBase> _paymentOperationProviders = new()
        {
            {typeof(Cash), new CashOperationValidator()},
            {typeof(Card), new CardOperationValidator()}
        };

        private BankPaymentProcessor _bankPaymentProcessor;

        public ProxyPaymentProcessor(BankPaymentProcessor bankPaymentProcessor)
        {
            _bankPaymentProcessor = bankPaymentProcessor;
        }

        public bool ProcessPayment(PaymentMethod paymentMethod, float amount)
        {
            if (paymentMethod.Balance < amount)
            {
                Console.Out.WriteLine("Operation Failed! Cause : Insufficient Funds!");
                return false;
            }

            if (!_paymentOperationProviders.ContainsKey(paymentMethod.GetType()))
            {
                Console.Out.WriteLine("Operation Failed! Cause : Unsupported type of payment!");
                return false;
            }
            if (_paymentOperationProviders[paymentMethod.GetType()].ValidatePayment(paymentMethod))
            {
                _bankPaymentProcessor.ProcessPayment(paymentMethod, amount);
                return true;
            }

            return false;
        }
    }
}