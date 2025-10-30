using System;

namespace Patterns.Command.Devices
{
    public class FloorLamp : LightDevice
    {
        public override void SwitchLight(bool isOn)
        {
            base.SwitchLight(isOn);
            Console.Out.WriteLine("Floor lamp has been switched {0}!", IsLightOn ? "on" : "off");
        }
    }
}