namespace Patterns.ChainOfResponsibility.Handlers
{
    public class LoadPlayerHandler : HandlerBase
    {
        public override bool Handle()
        {
            if (!TryLoadPlayer()) return false;
            if (!TryApplySavedSkin()) return false;
            return base.Handle();
        }

        private bool TryLoadPlayer()
        {
            return true;
        }

        private bool TryApplySavedSkin()
        {
            return true;
        }
    }
}