namespace Patterns.Facade.Items
{
    public class Item : IPurchasable
    {
        private readonly string _name;
        private readonly float _price;

        public Item(string name, float price)
        {
            _name = name;
            _price = price;
        }

        public float GetPrice() => _price;
    }
}