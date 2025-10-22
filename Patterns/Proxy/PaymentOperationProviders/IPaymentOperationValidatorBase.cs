using Patterns.Proxy.PaymentMethods;

namespace Patterns.Proxy.PaymentOperationProviders
{
    public interface IPaymentOperationValidatorBase
    {
        bool ValidatePayment(PaymentMethod paymentMethod);
    }
}