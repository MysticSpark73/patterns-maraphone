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
            BuildGameInitializationHandler();
            CreateGameInitializationManager(_gameInitializationHandler);
            _gameInitializationManager.Initialize();
        }

        private void CreateGameInitializationManager(IHandler handler) => 
            _gameInitializationManager = new GameInitializationManager(handler);

        private void BuildGameInitializationHandler()
        {
            _gameInitializationHandler = new LocalDataHandler();

            _gameInitializationHandler.SetNext(new LoadLevelHandler())
                .SetNext(new LoadPlayerHandler())
                .SetNext(new FinalizationHandler());
        }
    }
}