using System.Collections.Generic;
using Patterns.Command.Devices;

namespace Patterns.Command.Rooms
{
    public abstract class RoomBase
    {
        private List<DeviceBase> _devices = new();

        public void AddDevice(DeviceBase device) => _devices.Add(device);

        public void RemoveDevice(DeviceBase device)
        {
            if (_devices.Count == 0) return;

            _devices.Remove(device);
        }
    }
}