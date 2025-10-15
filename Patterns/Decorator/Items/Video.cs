using System;

namespace Patterns.Decorator.Items
{
    public class Video : MediaItem
    {
        protected string _director;
        protected string _title;
        protected int _length;
        
        public Video(int copies, string title, string director, int length)
        {
            Copies = copies;
            _title = title;
            _director = director;
            _length = length;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo   ------");
            Console.WriteLine("Title : {0}", _title);
            Console.WriteLine("Director : {0}", _director);
            Console.WriteLine("Length : {0}", _length);
            Console.WriteLine("Copies : {0}", Copies);
        }
    }
}