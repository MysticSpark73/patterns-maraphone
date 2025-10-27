using System;
using Patterns.ChainOfResponsibility.Handlers;

namespace Patterns.ChainOfResponsibility
{
    public class GameInitializationManager
    {
        private IHandler _gameInitializationHandler;

        public void Initialize()
        {
            if (!_gameInitializationHandler.Handle())
            {
                Console.Out.WriteLine("Initialization Failed!!!");
            }
        }
    }
}