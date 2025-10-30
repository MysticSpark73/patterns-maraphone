using Patterns.Command.Logger;

namespace Patterns.Command.Commands
{
    public class CommandBase : ICommand
    {
        protected CommandLogger _commandLogger;

        public CommandBase(CommandLogger commandLogger)
        {
            _commandLogger = commandLogger;
        }

        public virtual void Execute()
        {
            _commandLogger.Log(this);
        }

        public virtual void Undo()
        {
        }
    }
}