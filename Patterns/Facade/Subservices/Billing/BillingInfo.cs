namespace Patterns.Facade.Subservices.Billing
{
    public struct BillingInfo
    {
        public PaymentMethod paymentMethod = PaymentMethod.CreditCard;
        public string paymentData = "";
    }
}