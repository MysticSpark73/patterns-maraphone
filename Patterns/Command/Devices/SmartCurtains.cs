namespace Patterns.Command.Devices
{
    public class SmartCurtains : DeviceBase
    {
        public bool IsClosed { get; private set; }

        public void CloseCurtains()
        {
            IsClosed = true;
        }

        public void RaiseCurtains()
        {
            IsClosed = false;
        }
    }
}