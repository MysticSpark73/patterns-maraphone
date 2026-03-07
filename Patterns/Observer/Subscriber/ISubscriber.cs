namespace Patterns.Observer.Subscriber
{
    public interface ISubscriber
    {
        void Notify(string title);
    }
}