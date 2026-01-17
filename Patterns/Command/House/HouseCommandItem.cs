using Patterns.Command.Commands;
using Patterns.Command.Devices;
using Patterns.Command.Rooms;

namespace Patterns.Command.House
{
    public struct HouseCommandItem
    {
        public RoomBase room;
        public DeviceBase device;
        public CommandBase command;

        public HouseCommandItem(RoomBase room, DeviceBase device, CommandBase command)
        {
            this.room = room;
            this.device = device;
            this.command = command;
        }
    }
}