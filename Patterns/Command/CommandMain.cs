using System.Collections.Generic;
using Patterns.Command.Rooms;
using Patterns.Common;

namespace Patterns.Command
{
    public class CommandMain : IProgram
    {
        private House.House _house;
        public void Run(object[]? args = null)
        {
            BuildHouse();
        }

        private void BuildHouse()
        {
            //:_-(
            List<RoomBase> rooms = new List<RoomBase>();
            
            //todo: create rooms and fill them with devices

            _house = new House.House(rooms);
        }
    }
}