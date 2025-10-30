using System.Collections.Generic;
using Patterns.Command.Devices;
using Patterns.Command.Logger;
using Patterns.Command.Rooms;
using Patterns.Common;

namespace Patterns.Command
{
    public class CommandMain : IProgram
    {
        private CommandLogger _commandLogger;
        private House.House _house;
        public void Run(object[]? args = null)
        {
            CreateLogger();
            BuildHouse();
        }

        private void CreateLogger()
        {
            _commandLogger = new CommandLogger();
        }

        private void BuildHouse()
        {
            //:_-(
            _house = new House.House();
            
            _house.AddRoom(new LivingRoom(new List<DeviceBase>
            {
                new SmartLight(),
                new FloorLamp(),
                new FloorLamp(),
                new SmartCurtains(),
            }));
            
            _house.AddRoom(new Bathroom(new List<DeviceBase>
            {
                new SmartLight()
            }));
            
            _house.AddRoom(new Kitchen(new List<DeviceBase>
            {
                new SmartLight(),
                new SmartCurtains(),
                new SmartOven()
            }));
        }
    }
}