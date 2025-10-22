using Patterns.Proxy.PaymentMethods;

namespace Patterns.Proxy.PaymentOperationProviders
{
    public class CashOperationValidator : IPaymentOperationValidator<Cash>
    {
        public bool ValidatePayment(Cash cash) => true;

        public bool ValidatePayment(PaymentMethod paymentMethod) => ValidatePayment((Cash) paymentMethod);
    }
}