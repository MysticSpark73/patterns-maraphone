using System;

namespace Patterns.AbstractFactory.Furniture.Victorian
{
    public class VictorianChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("You are sitting on a Victorian chair");
        }
    }
}