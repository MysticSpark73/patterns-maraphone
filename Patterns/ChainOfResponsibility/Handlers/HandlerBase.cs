
using Patterns.ChainOfResponsibility.Data;

namespace Patterns.ChainOfResponsibility.Handlers
{
    public abstract class HandlerBase : IHandler
    {
        private IHandler? _handler;

        public virtual bool Handle(SaveData? saveData)
        {
            if (_handler != null)
            {
                return _handler.Handle(saveData);
            }
            
            return true;
        }

        public IHandler SetNext(IHandler handler)
        {
            _handler = handler;
            return handler;
        }
    }
}