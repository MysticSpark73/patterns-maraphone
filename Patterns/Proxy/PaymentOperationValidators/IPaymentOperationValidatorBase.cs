using Patterns.Proxy.PaymentMethods;

namespace Patterns.Proxy.PaymentOperationValidators
{
    public interface IPaymentOperationValidatorBase
    {
        bool ValidatePayment(PaymentMethod paymentMethod);
    }
}