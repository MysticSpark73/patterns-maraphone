using Patterns.Command.Rooms;

namespace Patterns.Command.House
{
    public class House
    {
        private readonly List<RoomBase> _rooms = new();

        public House()
        {
        }

        public void AddRoom(RoomBase room) => _rooms.Add(room);
    }
}