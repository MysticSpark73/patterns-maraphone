using Patterns.Common;
using Patterns.Facade.Items;
using Patterns.Facade.Subservices.Billing;
using Patterns.Facade.Subservices.Delivery;
using Patterns.Facade.Subservices.Orders;

namespace Patterns.Facade
{
    public class FacadeMain : IProgram
    {
        private BillingService _billingService;
        private DeliveryService _deliveryService;
        private OrderService _orderService;
        private ItemsDatabase _itemsDatabase;

        private ECommerceFacade _facade;
        
        public void Run(object[]? args = null)
        {
            CreateFacade();
            AssembleOrder();
        }

        private void CreateFacade()
        {
            _billingService = new BillingService();
            _deliveryService = new DeliveryService();
            _orderService = new OrderService();
            _itemsDatabase = new ItemsDatabase();

            _facade = new ECommerceFacade(_billingService, _deliveryService, _orderService, _itemsDatabase);
        }

        private void AssembleOrder()
        {
            _facade.AddItem("Smartwatch Series 6");
            _facade.AddItem("HD Webcam");
            _facade.AddItem("Graphic Drawing Tablet");
            _facade.AddItem("Bluetooth Speaker", 3);
            _facade.AddItem("Traveler’s Power Pack");
            _facade.SetBillingData(PaymentMethod.DebitCard, "4149 1111 2222 3333 4444, 012");
            _facade.ProceedToCheckout();
            _facade.SetDeliveryInfo("some Address in some City", DeliveryType.NovaPost);
            _facade.ProceedToPayment();
            
            
        }
    }
}