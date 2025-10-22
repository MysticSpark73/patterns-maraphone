using Patterns.Proxy.PaymentMethods;

namespace Patterns.Proxy.PaymentOperationProviders
{
    public interface IPaymentOperationValidator<T> : IPaymentOperationValidatorBase where T : PaymentMethod
    {
        bool ValidatePayment(T paymentMethod);
    }
}