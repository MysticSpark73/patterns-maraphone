using System;

namespace Patterns.Bridge.Makes
{
    public class Tesla : Make
    {
        public override void Start()
        {
            Console.WriteLine("Press the button");
        }

        public void EnableTheAutopilotMode(bool value)
        {
            Console.WriteLine("Autopilot mode is {0}", value ? "enabled" : "disabled");
        }

        public void Charge()
        {
            throw new Exception("There is no electric car charging station in your country!");
        }
    }
}