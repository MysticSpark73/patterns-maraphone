using System;

namespace Patterns.Bridge.Makes
{
    public class Honda : Make
    {
        public override void Start()
        {
            Console.WriteLine("Press F to start the car");
        }

        public void EnableCruiseControl(bool value)
        {
            Console.WriteLine("Cruise Control is {0}", value ? "enabled" : "disabled");
        }

        public void EnableTractionControl(bool value)
        {
            Console.WriteLine("Traction Control is {0}", value ? "enabled" : "disabled");
        }

        public void EnableSeatHeating(bool value)
        {
            Console.WriteLine("Seat Heating is {0}", value ? "enabled" : "disabled");
        }

        public void EnableRecuperation(bool value)
        {
            Console.WriteLine("Recuperation is {0}", value ? "enabled" : "disabled");
        }
    }
}