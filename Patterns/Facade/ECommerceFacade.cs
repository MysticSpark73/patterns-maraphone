using Patterns.Facade.Items;
using Patterns.Facade.Subservices.Billing;
using Patterns.Facade.Subservices.Delivery;
using Patterns.Facade.Subservices.Orders;

namespace Patterns.Facade
{
    public class ECommerceFacade
    {
        private BillingService _billingService;
        private DeliveryService _deliveryService;
        private OrderService _orderService;
        private ItemsDatabase _itemsDatabase;

        private OrderInfo? _currentOrderInfo;

        public ECommerceFacade(BillingService billingService, DeliveryService deliveryService, OrderService orderService, ItemsDatabase itemsDatabase)
        {
            _billingService = billingService;
            _deliveryService = deliveryService;
            _orderService = orderService;
            _itemsDatabase = itemsDatabase;

            _currentOrderInfo = null;
        }

        public void AddItem(string name, int amount = 1)
        {
            if (_currentOrderInfo == null)
            {
                CreateNewOrder();
            }

            IPurchasable item;
            if (_itemsDatabase.TryTakeItem(name, out item, amount))
            {
                _currentOrderInfo?.Order.AddItem(item, amount);
            }
        }

        public void RemoveItem(string name, int amount = 1)
        {
            if (_currentOrderInfo == null) return;
            
            IPurchasable item;
            if (_itemsDatabase.TryTakeItem(name, out item, amount))
            {
                _currentOrderInfo?.Order.RemoveItem(item, amount);
            }
        }

        public void SetBillingData(PaymentMethod paymentMethod, string data)
        {
            _billingService.ChosePaymentMethod(_currentOrderInfo, paymentMethod);
            _billingService.SetPaymentData(_currentOrderInfo, data);
        }

        public void ProceedToCheckout()
        {
            _billingService.ProceedToCheckout(_currentOrderInfo);
        }

        public void ProceedToPayment()
        {
            _billingService.ProceedToPayment(_currentOrderInfo);
        }

        public void SetDeliveryInfo(string address, DeliveryType deliveryType)
        {
            _deliveryService.SetDeliveryInfo(_currentOrderInfo, new DeliveryInfo(address, deliveryType));
        }

        public void ProceedToDelivery()
        {
            _deliveryService.ProceedToDelivery(_currentOrderInfo);
        }

        private void CreateNewOrder()
        {
            _currentOrderInfo = new OrderInfo(_orderService.CreateOrder);
        }
    }
}