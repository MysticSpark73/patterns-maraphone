using System;

namespace Patterns.Decorator.Items
{
    public class Book : MediaItem
    {
        private string _name;
        private string _author;
        
        public Book(int copies, string name, string author)
        {
            Copies = copies;
            _name = name;
            _author = author;
        }

        public override void Display()
        {
            Console.Out.WriteLine("\nBook   -----");
            Console.Out.WriteLine("Name : {0}", _name);
            Console.Out.WriteLine("Author : {0}", _author);
            Console.Out.WriteLine("Copies : {0}", Copies);
        }
    }
}