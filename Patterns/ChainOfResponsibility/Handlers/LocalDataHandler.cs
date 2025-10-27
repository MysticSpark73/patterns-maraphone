namespace Patterns.ChainOfResponsibility.Handlers
{
    public class LocalDataHandler : HandlerBase
    {
        public override bool Handle()
        {
            if (!TryLoadSavedData()) return false;
            if (!TryLoadResources()) return false;
            if (!TryLoadAssets()) return false;
            
            return base.Handle();
        }

        private bool TryLoadSavedData()
        {
            return true;
        }

        private bool TryLoadResources()
        {
            return true;
        }

        private bool TryLoadAssets()
        {
            return true;
        }
    }
}