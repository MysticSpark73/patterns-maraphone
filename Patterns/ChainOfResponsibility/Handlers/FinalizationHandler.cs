namespace Patterns.ChainOfResponsibility.Handlers
{
    public class FinalizationHandler : HandlerBase
    {
        public override bool Handle()
        {
            if (!TryFinalize()) return false;
            return base.Handle();
        }

        private bool TryFinalize()
        {
            return true;
        }
    }
}