namespace Patterns.Observer.Publisher
{
    public class PewDiePie : PublisherBase
    {
        public void ReleaseVideo(string title)
        {
            Console.Out.WriteLine($"\nPewDiePie released new video \"{title}\"!");
            Notify(title);
        }
    }
}