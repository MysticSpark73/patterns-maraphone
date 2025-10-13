namespace Patterns.Composite
{
    public class Item : IPriceable
    {
        private string _name;
        private float _price;

        public Item(string name, float price)
        {
            _name = name;
            _price = price;
        }

        public float GetPrice()
        {
            return _price;
        }
    }
}