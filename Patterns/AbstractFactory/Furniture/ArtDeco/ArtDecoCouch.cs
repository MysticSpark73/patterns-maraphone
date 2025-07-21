using System;

namespace Patterns.AbstractFactory.Furniture.ArtDeco
{
    public class ArtDecoCouch : ICouch
    {
        public void SitOn()
        {
            Console.WriteLine("You are sitting on an Art Deco Couch");
        }

        public void LayOn()
        {
            Console.WriteLine("You are lying on an Art Deco Couch");
        }
    }
}