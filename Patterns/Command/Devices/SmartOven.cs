namespace Patterns.Command.Devices
{
    public class SmartOven : DeviceBase
    {
        public bool IsOn { get; private set; }
        public int Temperature { get; private set; }

        public void SetEnabled(bool isOn)
        {
            IsOn = isOn;
        }

        public void SetTemperature(int temperature)
        {
            Temperature = temperature;
        }
    }
}