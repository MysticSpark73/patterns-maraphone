using Patterns.Command.Devices;

namespace Patterns.Command.Rooms
{
    public class Kitchen : RoomBase
    {
        public Kitchen(List<DeviceBase> devices) : base(devices)
        {
        }
    }
}