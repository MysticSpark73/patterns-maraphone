using Patterns.Proxy.PaymentMethods;

namespace Patterns.Proxy.PaymentSystem
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(PaymentMethod paymentMethod, float amount);
    }
}