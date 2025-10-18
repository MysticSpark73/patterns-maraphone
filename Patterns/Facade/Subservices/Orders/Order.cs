using System;
using System.Collections.Generic;
using Patterns.Facade.Items;

namespace Patterns.Facade.Subservices.Orders
{
    public class Order : IPurchasable
    {
        private Dictionary<IPurchasable, int> _items;

        public void AddItem(IPurchasable item, int amount = 1)
        {
            if (_items.ContainsKey(item))
            {
                _items[item] += amount;
            }
            else
            {
                _items.Add(item, amount);
            }
            Console.Out.WriteLine($"Added items {item.GetName()} x{_items[item]}");
        }

        public void RemoveItem(IPurchasable item, int amount = 1)
        {
            if (_items.ContainsKey(item))
            {
                _items[item] = Math.Max(0, _items[item] - amount);
            }
        }
        
        public float GetPrice()
        {
            float price = 0;
            if (_items.Count == 0) return price;
            
            foreach (var item in _items)
            {
                price += item.Key.GetPrice() * item.Value;
            }

            return price;
        }

        public string GetName()
        {
            string name = String.Empty;
            foreach (var item in _items)
            {
                name += $"{item.Key.GetName()} : x{item.Value}\n";
            }

            return name;
        }
    }
}