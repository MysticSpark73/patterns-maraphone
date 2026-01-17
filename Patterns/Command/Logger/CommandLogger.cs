using Patterns.Command.Commands;

namespace Patterns.Command.Logger
{
    public class CommandLogger
    {
        private Stack<ICommand> _commandsLog = new ();

        public void Log(ICommand command) => _commandsLog.Push(command);

        public ICommand Pop() => _commandsLog.Pop();
    }
}