using System;
using Patterns.Facade.Subservices.Orders;

namespace Patterns.Facade.Subservices.Billing
{
    public class BillingService
    {
        public void ChosePaymentMethod(OrderInfo orderInfo, PaymentMethod paymentMethod)
        {
            orderInfo.SetPaymentMethod(paymentMethod);
        }

        public void SetPaymentData(OrderInfo orderInfo, string paymentData)
        {
            orderInfo.SetPaymentData(paymentData);
        }

        public void ProceedToCheckout(OrderInfo orderInfo)
        {
            if (CanProceedToCheckout(orderInfo.BillingInfo))
            {
                orderInfo.SetStatus(OrderStatus.Checkout);
            }
        }

        public bool ProceedToPayment(OrderInfo orderInfo)
        {
            if (TryPerformPaymentOperation(orderInfo.BillingInfo))
            {
                orderInfo.SetPaymentComplete(true);
                orderInfo.SetStatus(OrderStatus.PaymentComplete);
                Console.Out.WriteLine($"The order is {orderInfo.Order.GetName()}\nTotal Cost = {orderInfo.GetPrice()}");
                return true;
            }

            orderInfo.SetPaymentComplete(false);
            return false;
        }

        public bool TryPerformPaymentOperation(BillingInfo billingInfo)
        {
            switch (billingInfo.paymentMethod)
            {
                case PaymentMethod.CreditCard:
                case PaymentMethod.DebitCard:
                    return !billingInfo.paymentData.Equals(String.Empty);
                case PaymentMethod.Cash:
                    return false;
            }
            return false;
        }

        private bool CanProceedToCheckout(BillingInfo billingInfo)
        {
            switch (billingInfo.paymentMethod)
            {
                case PaymentMethod.CreditCard:
                case PaymentMethod.DebitCard:
                    return !billingInfo.paymentData.Equals(String.Empty);
                case PaymentMethod.Cash:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}