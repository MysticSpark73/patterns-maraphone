namespace Patterns.Facade.Subservices.Billing
{
    public enum PaymentMethod : byte
    {
        CreditCard = 0,
        DebitCard = 1,
        Cash = 2,
    }
}