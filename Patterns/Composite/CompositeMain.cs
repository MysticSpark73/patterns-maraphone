using System;
using Patterns.Common;

namespace Patterns.Composite
{
    public class CompositeMain : IProgram
    {
        public void Run(object[]? args = null)
        {
            CreateItems();
        }

        private void CreateItems()
        {
            Item book = new Item("book", 12.35f);
            Item book1 = new Item("book1", 4.53f);
            Item book2 = new Item("book2", 27.11f);
            Item smartphone = new Item("smartphone", 483.97f);
            Item parfume = new Item("parfume", 54.17f);
            Item laptop = new Item("laptop", 717.74f);
            Item cup = new Item("Cup", 2.25f);
            Item lamp = new Item("lamp", 7.12f);
            Item guitar = new Item("guitar", 515.87f);
            Item chair = new Item("chair", 10.14f);
            Item vine = new Item("vine", 86.19f);

            Package packageBooks = new Package();
            packageBooks.Add(book);
            packageBooks.Add(book1);
            packageBooks.Add(book2);

            Package packageTech = new Package();
            packageTech.Add(smartphone);
            packageTech.Add(laptop);

            Package packageDate = new Package();
            packageDate.Add(parfume);
            packageDate.Add(lamp);

            Package packageHome = new Package();
            packageHome.Add(chair);
            packageHome.Add(vine);

            Package order1 = new Package();
            order1.Add(guitar);
            
            Package order2 = new Package();
            order2.Add(packageBooks);
            order2.Add(packageTech);
            
            Package order3 = new Package();
            order3.Add(packageDate);
            order3.Add(packageHome);
            order3.Add(cup);

            Package[] orders = new[]
            {
                order1, order2, order3
            };

            for (int i = 0; i < orders.Length; i++)
            {
                Console.WriteLine("Order {0} costs {1}", i, orders[i].GetPrice());
            }
        }
    }
}