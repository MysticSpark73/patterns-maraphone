using System.Collections.Generic;

namespace Patterns.Composite
{
    public class Package : IPriceable
    {
        private readonly List<IPriceable> _items = new ();

        public void Add(IPriceable item)
        {
            _items.Add(item);
        }

        public void Remove(IPriceable item)
        {
            if (_items.Count == 0 || !_items.Contains(item)) return;
            _items.Remove(item);
        }

        public float GetPrice()
        {
            float price = 0;
            _items.ForEach(i => price += i.GetPrice());

            return price;
        }
    }
}