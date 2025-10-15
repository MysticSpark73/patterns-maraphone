using System;
using Patterns.Common;
using Patterns.Decorator.Decorators;
using Patterns.Decorator.Items;

namespace Patterns.Decorator
{
    public class DecoratorMain : IProgram
    {
        public void Run(object[]? args = null)
        {
            Book mockingBird = new Book(14, "To Kill a Mockingbird", "Harper Lee");
            Book prideAndPrejudice = new Book(27, "Pride and Prejudice", "Jane Austen");
            Book the1984 = new Book(1984, "1984", "George Orwell");

            Video shindlersList = new Video(38, "Schindler's List", "Steven Spielberg", 195);
            Video forrestGump = new Video(38, "Forrest Gump", "Robert Zemeckis", 142);
            Video fightClub = new Video(38, "Fight Club", "David Fincher", 139);
            
            the1984.Display();
            shindlersList.Display();

            forrestGump.Display();
            
            Console.Out.WriteLine("Make item borrowable");
            
            BorrowableDecorator borrowable = new BorrowableDecorator(forrestGump);
            
            borrowable.BorrowItem("Customer 1");
            borrowable.BorrowItem("Customer 2");
            
            borrowable.Display();
        }
    }
}