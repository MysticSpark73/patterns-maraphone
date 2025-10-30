namespace Patterns.Command.Devices
{
    public abstract class LightDevice : DeviceBase
    {
        public bool IsLightOn { get; private set; }

        public virtual void SwitchLight(bool isOn)
        {
            IsLightOn = isOn;
        }
    }
}