using Patterns.Common;
using Patterns.Observer.Publisher;

namespace Patterns.Observer
{
    public class ObserverMain : IProgram
    {
        private PewDiePie _pewDiePie;
        private Subscriber.Subscriber _subscriber;

        public void Run(object[]? args = null)
        {
            CreatePublisher();
            ReleaseVideos();
        }

        private void CreatePublisher()
        {
            _pewDiePie = new PewDiePie();
            _pewDiePie.AddSubscriber(new Subscriber.Subscriber("Subscriber 1"));
            _pewDiePie.AddSubscriber(new Subscriber.Subscriber("Subscriber 2"));
            _subscriber = new Subscriber.Subscriber("Subscriber 3");
            _pewDiePie.AddSubscriber(_subscriber);
        }

        private void ReleaseVideos()
        {
            _pewDiePie.ReleaseVideo("help, Im going through a midlife crisis...");
            _pewDiePie.ReleaseVideo("Thanks for 15 years");
            _pewDiePie.RemoveSubscriber(_subscriber);
            _pewDiePie.ReleaseVideo("STOP. Using AI Right now");
        }
    }
}