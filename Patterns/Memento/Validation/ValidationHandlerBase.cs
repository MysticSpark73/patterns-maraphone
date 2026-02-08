namespace Patterns.Memento.Validation
{
    public class ValidationHandlerBase : IValidationHandler
    {
        private IValidationHandler? _handler;
        
        public virtual bool Handle()
        {
            if (_handler != null)
            {
                return _handler.Handle();
            }

            return true;
        }

        public IValidationHandler SetNext(IValidationHandler handler)
        {
            _handler = handler;
            return handler;
        }
    }
}