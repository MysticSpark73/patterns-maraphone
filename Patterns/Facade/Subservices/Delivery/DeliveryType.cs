namespace Patterns.Facade.Subservices.Delivery
{
    public enum DeliveryType : byte
    {
        Post = 0,
        NovaPost = 1,
        Meest = 2,
        FedEx = 3,
        International = 4,
        Courier = 5
    }
}