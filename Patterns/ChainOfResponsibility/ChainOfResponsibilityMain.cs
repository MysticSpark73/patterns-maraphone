using Patterns.ChainOfResponsibility.Handlers;
using Patterns.Common;

namespace Patterns.ChainOfResponsibility
{
    public class ChainOfResponsibilityMain : IProgram
    {
        private GameInitializationManager _gameInitializationManager;
        private IHandler _gameInitializationHandler;
        
        public void Run(object[]? args = null)
        {
            CreateGameInitializationManager();
            BuildGameInitializationHandler();
        }

        private void CreateGameInitializationManager() => _gameInitializationManager = new GameInitializationManager();

        private void BuildGameInitializationHandler()
        {
            _gameInitializationHandler = new LocalDataHandler();
            _gameInitializationHandler.SetNext(
                new LoadLevelHandler().SetNext(
                    new LoadPlayerHandler().SetNext(new FinalizationHandler())));
        }
    }
}