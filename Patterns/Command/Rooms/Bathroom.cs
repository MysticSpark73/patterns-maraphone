using System.Collections.Generic;
using Patterns.Command.Devices;

namespace Patterns.Command.Rooms
{
    public class Bathroom : RoomBase
    {
        public Bathroom(List<DeviceBase> devices) : base(devices)
        {
        }
    }
}