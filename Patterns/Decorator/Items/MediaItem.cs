namespace Patterns.Decorator.Items
{
    public abstract class MediaItem
    {
        private int _copies;

        public int Copies
        {
            get => _copies;
            set => _copies = value;
        }

        public abstract void Display();
    }
}