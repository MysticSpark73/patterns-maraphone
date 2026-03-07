namespace Patterns.Observer.Subscriber
{
    public class Subscriber : ISubscriber
    {
        private string _name;

        public Subscriber(string name)
        {
            _name = name;
        }

        public void Notify(string title)
        {
            Console.Out.WriteLine($"{_name} has added \"{title}\" to Watch Later list!");
        }
    }
}