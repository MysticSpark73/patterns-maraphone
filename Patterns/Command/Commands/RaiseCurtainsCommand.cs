using Patterns.Command.Devices;
using Patterns.Command.Logger;

namespace Patterns.Command.Commands
{
    public class RaiseCurtainsCommand : CommandBase
    {
        private SmartCurtains _curtains;
        private bool _isClosed;
        private bool? _cachedState;
        
        public RaiseCurtainsCommand(CommandLogger commandLogger, SmartCurtains curtains, bool isClosed) : base(commandLogger)
        {
            _curtains = curtains;
            _isClosed = isClosed;
        }

        public override void Execute()
        {
            base.Execute();
            _cachedState = _curtains.IsClosed;
            
            PerformAction(_isClosed);
        }

        public override void Undo()
        {
            if (_cachedState != null)
            {
                PerformAction(_cachedState.Value);
                _cachedState = null;
            }
        }

        private void PerformAction(bool isClosed)
        {
            if (isClosed)
            {
                _curtains.CloseCurtains();
            }
            else
            {
                _curtains.RaiseCurtains();
            }
            Console.Out.WriteLine($"The curtains are {0}", _isClosed ? "closed" : "open");
        }
    }
}