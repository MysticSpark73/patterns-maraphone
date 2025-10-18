using System;
using Patterns.Facade.Items;
using Patterns.Facade.Subservices.Billing;
using Patterns.Facade.Subservices.Delivery;

namespace Patterns.Facade.Subservices.Orders
{
    public class OrderInfo : IPurchasable
    {
        public Order Order => _order;
        public BillingInfo BillingInfo => _billingInfo;

        private Order _order;
        private bool _isPaymentComplete;
        private OrderStatus _status = OrderStatus.Created;
        private DeliveryInfo? _deliveryInfo;
        private BillingInfo _billingInfo;

        public OrderInfo(Order order)
        {
            _order = order;
        }

        public OrderInfo SetPaymentComplete(bool isPaymentComplete)
        {
            _isPaymentComplete = isPaymentComplete;
            Console.Out.WriteLine("Payment is {0}", isPaymentComplete ? "Successful" : "Failed");
            return this;
        }

        public OrderInfo SetStatus(OrderStatus status)
        {
            _status = status;
            Console.Out.WriteLine($"Order status has been changed to {_status}");
            return this;
        }

        public OrderInfo SetDeliveryInfo(DeliveryInfo deliveryInfo)
        {
            _deliveryInfo = deliveryInfo;
            Console.Out.WriteLine($"Delivery info is set to {deliveryInfo.address}, to be delivered via {deliveryInfo.deliveryType}");
            return this;
        }

        public OrderInfo SetPaymentMethod(PaymentMethod paymentMethod)
        {
            _billingInfo.paymentMethod = paymentMethod;
            Console.Out.WriteLine($"Payment Method set to {paymentMethod}");
            return this;
        }

        public OrderInfo SetPaymentData(string paymentData)
        {
            _billingInfo.paymentData = paymentData;
            Console.Out.WriteLine($"PaymentData set to {paymentData}");
            return this;
        }

        public float GetPrice()
        {
            return _order.GetPrice() + (_deliveryInfo?.GetPrice() ?? 0);
        }
    }
}