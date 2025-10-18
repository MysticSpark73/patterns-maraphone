using Patterns.Facade.Subservices.Orders;

namespace Patterns.Facade.Subservices.Delivery
{
    public class DeliveryService
    {
        public void SetDeliveryInfo(OrderInfo orderInfo, DeliveryInfo deliveryInfo)
        {
            orderInfo.SetDeliveryInfo(deliveryInfo);
        }

        public void ProceedToDelivery(OrderInfo orderInfo)
        {
            orderInfo.SetStatus(OrderStatus.WaitingDelivery);
        }
    }
}