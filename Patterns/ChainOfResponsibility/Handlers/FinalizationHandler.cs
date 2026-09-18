using Patterns.ChainOfResponsibility.Data;

namespace Patterns.ChainOfResponsibility.Handlers
{
    public class FinalizationHandler : HandlerBase
    {
        public override bool Handle(SaveData saveData)
        {
            if (!TryFinalize()) return false;
            return base.Handle(saveData);
        }

        private bool TryFinalize()
        {
            Console.Out.WriteLine("Finalizing game initialization...");
            return true;
        }
    }
}