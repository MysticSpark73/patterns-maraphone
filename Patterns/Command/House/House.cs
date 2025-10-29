using System.Collections.Generic;
using Patterns.Command.Rooms;

namespace Patterns.Command.House
{
    public class House
    {
        private List<RoomBase> _rooms;

        public House(List<RoomBase> rooms)
        {
            _rooms = rooms;
        }
    }
}