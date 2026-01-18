using Patterns.Common;

namespace Patterns.Iterator
{
    public class IteratorMain : IProgram
    {
        private ItemCollection<string> _itemCollection;
        public void Run(object[]? args = null)
        {
            CreateItemCollection();
            IterateItemCollection();
        }

        private void CreateItemCollection()
        {
            _itemCollection = new ItemCollection<string>();
            _itemCollection.Add("Item 0");
            _itemCollection.Add("Item 1");
            _itemCollection.Add("Item 2");
            _itemCollection.Add("Item 3");
            _itemCollection.Add("Item 4");
            _itemCollection.Add("Item 5");
            _itemCollection.Add("Item 6");
            _itemCollection.Add("Item 7");
            _itemCollection.Add("Item 8");
        }

        private void IterateItemCollection()
        {
            Console.Out.WriteLine("Iterating Front to Back\n");
            foreach (var item in _itemCollection.GetFrontToBackIterator())
            {
                Console.Out.WriteLine(item);
            }

            Console.Out.WriteLine("Iterating Back to Front\n");
            foreach (var item in _itemCollection.GetBackToFrontIterator())
            {
                Console.Out.WriteLine(item);
            }

            Console.Out.WriteLine($"Iterating From 2 to {_itemCollection.Count - 2} in steps of 2\n");
            foreach (var item in _itemCollection.GetFromToStepIterator(2, _itemCollection.Count - 2, 2))
            {
                Console.Out.WriteLine(item);
            }
        }
    }
}