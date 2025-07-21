using System;

namespace Patterns.AbstractFactory.Furniture.Modern
{
    public class ModernChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("You are sitting on a Modern Chair");
        }
    }
}