using Patterns.Observer.Subscriber;

namespace Patterns.Observer.Publisher
{
    public abstract class PublisherBase
    {
        protected List<ISubscriber> _subscribers = new();

        public void AddSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            if (_subscribers.Contains(subscriber))
            {
                _subscribers.Remove(subscriber);
            }
        }

        public void Notify(string title)
        {
            _subscribers.ForEach(s => s.Notify(title));
        }
    }
}