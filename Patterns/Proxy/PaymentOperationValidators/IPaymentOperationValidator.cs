using Patterns.Proxy.PaymentMethods;

namespace Patterns.Proxy.PaymentOperationValidators
{
    public interface IPaymentOperationValidator<T> : IPaymentOperationValidatorBase where T : PaymentMethod
    {
        bool ValidatePayment(T paymentMethod);
    }
}