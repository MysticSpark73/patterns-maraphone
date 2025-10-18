using System.Collections.Generic;

namespace Patterns.Facade.Items
{
    public class Bundle : IPurchasable
    {
        private string _name;
        private List<IPurchasable> _items;
        
        public Bundle(string name, List<IPurchasable> items)
        {
            _name = name;
            _items = items;
        }

        public float GetPrice()
        {
            float price = 0;
            if (_items.Count == 0) return price;

            foreach (var item in _items)
            {
                price += item.GetPrice();
            }

            return price;
        }
    }
}