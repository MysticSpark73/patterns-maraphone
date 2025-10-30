using System.Collections.Generic;
using Patterns.Command.Commands;

namespace Patterns.Command.Devices
{
    public abstract class DeviceBase
    {
        private List<ICommand> _commands = new ();

        public void AddCommand(ICommand command) => _commands.Add(command);

        public void RemoveCommand(ICommand command)
        {
            if (_commands.Count == 0) return;

            _commands.Remove(command);
        }

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
}