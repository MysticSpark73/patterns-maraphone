namespace Patterns.Facade.Items
{
    public interface IPurchasable
    {
        public abstract float GetPrice();

        public virtual string GetName()
        {
            return string.Empty;
        }
    }
}