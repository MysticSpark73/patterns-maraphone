using Patterns.Command.Commands;

namespace Patterns.Command.Logger
{
    public class CommandLogger
    {
        private Stack<ICommand> _commandsLog = new ();

        public void Log(ICommand command)
        {
            _commandsLog.Push(command);
            Console.Out.WriteLine($"Command {command.GetType()} was added to the log!");
        }

        public bool TryPop(out ICommand? command)
        {
            command = null;
            if (_commandsLog.Count > 0)
            {
                command = _commandsLog.Pop();
                Console.Out.WriteLine($"Command {command.GetType()} was extracted from the log!");
                return true;
            }

            return false;
        }
    }
}