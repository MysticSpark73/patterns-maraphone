using System;

namespace Patterns.Bridge.Makes
{
    public class Ford : Make
    {
        public virtual void EnableSportMode(bool value)
        {
            Console.WriteLine("Sport mode is {0}", value ? "on" : "off");
        }

        public override void Start()
        {
            Console.WriteLine("Start the car");
        }
    }
}