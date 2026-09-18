using Patterns.Command.Commands;
using Patterns.Command.Devices;
using Patterns.Command.House;
using Patterns.Command.Logger;
using Patterns.Command.Rooms;
using Patterns.Common;

namespace Patterns.Command
{
    public class CommandMain : IProgram
    {
        private CommandLogger _commandLogger;
        private House.House _house;
        private List<HouseCommandItem> _houseCommandsMap = new ();
        
        public void Run(object[]? args = null)
        {
            CreateLogger();
            BuildHouse();
            CreateCommands();
            ExecuteCommands();
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

        private void CreateCommands()
        {
            _houseCommandsMap.Clear();
            
            foreach (var room in _house.GetRooms())
            {
                CreateCommandsForDevicesInRoom(room);
            }
        }

        private void CreateCommandsForDevicesInRoom(RoomBase room)
        {
            foreach (var lightDevice in room.GetDevices<LightDevice>())
            {
                SwitchLightCommand switchLightCommand =
                    new SwitchLightCommand(_commandLogger, lightDevice, !lightDevice.IsLightOn);
                lightDevice.AddCommand(switchLightCommand);
                    
                _houseCommandsMap.Add(new HouseCommandItem(room, lightDevice, switchLightCommand));
            }
            
            foreach (var curtains in room.GetDevices<SmartCurtains>())
            {
                RaiseCurtainsCommand raiseCurtainsCommand =
                    new RaiseCurtainsCommand(_commandLogger, curtains, !curtains.IsClosed);
                curtains.AddCommand(raiseCurtainsCommand);

                _houseCommandsMap.Add(new HouseCommandItem(room, curtains, raiseCurtainsCommand));
            }

            foreach (var oven in room.GetDevices<SmartOven>())
            {
                ConfigureOvenCommand configureOvenCommand =
                    new ConfigureOvenCommand(_commandLogger, oven, !oven.IsOn, 280);
                oven.AddCommand(configureOvenCommand);
                
                _houseCommandsMap.Add(new HouseCommandItem(room, oven, configureOvenCommand));
            }
        }

        private void ExecuteCommands()
        {
            foreach (var houseCommandItem in _houseCommandsMap.Where(i => i.device is LightDevice))
            {
                houseCommandItem.command.Execute();
            }

            foreach (var houseCommandItem in _houseCommandsMap.Where(i => i.device is SmartCurtains))
            {
                houseCommandItem.command.Execute();
            }

            foreach (var houseCommandItem in _houseCommandsMap.Where(i => i.device is SmartOven))
            {
                houseCommandItem.command.Execute();
            }
        }
    }
}