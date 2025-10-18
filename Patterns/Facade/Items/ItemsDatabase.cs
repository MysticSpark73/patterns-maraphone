using System.Collections.Generic;
using Patterns.Facade.Items;

namespace Patterns.Facade.Systems
{
    public class ItemsDatabase
    {
        public static Dictionary<IPurchasable, int> Items = new()
        {
            {new Item("Wireless Mouse", 29.99f), 120},
            {new Item("Mechanical Keyboard", 89.50f), 75},
            {new Item("USB-C Charger 65W", 39.99f), 60},
            {new Item("Noise Cancelling Headphones", 159.99f), 40},
            {new Item("Smartwatch Series 6", 249.99f), 35},
            {new Item("4K Monitor 27-inch", 329.00f), 20},
            {new Item("Gaming Chair", 199.99f), 15},
            {new Item("External SSD 1TB", 119.49f), 50},
            {new Item("Bluetooth Speaker", 59.95f), 90},
            {new Item("Smart LED Bulb", 14.99f), 150},
            {new Item("Laptop Stand", 34.99f), 85},
            {new Item("Wireless Earbuds", 79.99f), 65},
            {new Item("Portable Power Bank 20000mAh", 49.99f), 70},
            {new Item("Ergonomic Desk Lamp", 24.99f), 110},
            {new Item("HD Webcam", 69.99f), 40},
            {new Item("Graphic Drawing Tablet", 139.99f), 25},
            {new Item("Smart Home Hub", 99.99f), 30},
            {new Item("Fitness Tracker Band", 54.95f), 55},
            {new Item("VR Headset", 399.99f), 10},
            {new Item("Portable Projector", 249.00f), 18},
            
            // Bundles
            { new Bundle("Home Office Starter Pack", new List<IPurchasable>
            {
                new Item("Wireless Mouse", 29.99f),
                new Item("Mechanical Keyboard", 89.50f),
                new Item("Laptop Stand", 34.99f),
                new Item("Ergonomic Desk Lamp", 24.99f)
            }), 10 },

            { new Bundle("Ultimate Gamer Bundle", new List<IPurchasable>
            {
                new Item("Gaming Chair", 199.99f),
                new Item("Noise Cancelling Headphones", 159.99f),
                new Item("4K Monitor 27-inch", 329.00f),
                new Item("Wireless Mouse", 29.99f),
                new Item("Mechanical Keyboard", 89.50f)
            }), 5 },

            { new Bundle("Smart Home Essentials", new List<IPurchasable>
            {
                new Item("Smart Home Hub", 99.99f),
                new Item("Smart LED Bulb", 14.99f),
                new Item("Bluetooth Speaker", 59.95f)
            }), 12 },

            { new Bundle("Creative Designer Kit", new List<IPurchasable>
            {
                new Item("Graphic Drawing Tablet", 139.99f),
                new Item("HD Webcam", 69.99f),
                new Item("External SSD 1TB", 119.49f)
            }), 8 },

            { new Bundle("Traveler’s Power Pack", new List<IPurchasable>
            {
                new Item("Portable Power Bank 20000mAh", 49.99f),
                new Item("USB-C Charger 65W", 39.99f),
                new Item("Wireless Earbuds", 79.99f)
            }), 14 }
        };
    }
}