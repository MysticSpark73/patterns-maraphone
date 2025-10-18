using System;
using Patterns.Facade.Items;

namespace Patterns.Facade.Subservices.Delivery
{
    public class DeliveryInfo : IPurchasable
    {
        public DeliveryType deliveryType;
        public string address;

        public DeliveryInfo(string address, DeliveryType deliveryType)
        {
            this.deliveryType = deliveryType;
            this.address = address;
        }

        private float GetDeliveryFee() => deliveryType switch
        {
            DeliveryType.Post => 3.57f,
            DeliveryType.NovaPost => 5f,
            DeliveryType.Meest => 4.15f,
            DeliveryType.FedEx => 10f,
            DeliveryType.International => 15f,
            DeliveryType.Courier => 12f,
            _ => throw new ArgumentOutOfRangeException()
        };

        public float GetPrice() => GetDeliveryFee();
    }
}