using Patterns.Decorator.Items;

namespace Patterns.Decorator.Decorators
{
    public abstract class MediaItemDecorator : MediaItem
    {
        protected MediaItem _item;
        
        protected MediaItemDecorator(MediaItem item)
        {
            _item = item;
        }

        public override void Display()
        {
            _item.Display();
        }
    }
}