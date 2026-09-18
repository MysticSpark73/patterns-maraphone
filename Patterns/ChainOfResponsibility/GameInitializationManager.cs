using System;
using Patterns.ChainOfResponsibility.Data;
using Patterns.ChainOfResponsibility.Handlers;

namespace Patterns.ChainOfResponsibility
{
    public class GameInitializationManager
    {
        private IHandler _gameInitializationHandler;

        public GameInitializationManager(IHandler gameInitializationHandler)
        {
            _gameInitializationHandler = gameInitializationHandler;
        }

        public void Initialize()
        {
            if (!_gameInitializationHandler.Handle(null))
            {
                Console.Out.WriteLine("Initialization Failed!!!");
                return;
            }
            Console.Out.WriteLine("Game Initialized Successfully!!!");
        }
    }
}