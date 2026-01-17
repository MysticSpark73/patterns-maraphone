
namespace Patterns.Command.Devices
{
    public class SmartLight : LightDevice
    {
        public override void SwitchLight(bool isOn)
        {
            base.SwitchLight(isOn);
            Console.Out.WriteLine("Very Smart Light is turned {0}", IsLightOn ? "on" : "off");
        }
    }
}