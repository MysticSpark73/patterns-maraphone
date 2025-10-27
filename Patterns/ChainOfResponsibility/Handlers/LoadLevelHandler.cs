using System;
using Patterns.ChainOfResponsibility.Data;

namespace Patterns.ChainOfResponsibility.Handlers
{
    public class LoadLevelHandler : HandlerBase
    {
        public override bool Handle()
        {
            //todo: replace with LevelData from previousStep
            if (!TryLoadLevel(new LevelData())) return false;
            
            return base.Handle();
        }

        private bool TryLoadLevel(LevelData levelData)
        {
            if (levelData.CurrentLevel <0 || levelData.CurrentLevel >= levelData.LevelsCount)
            {
                Console.Out.WriteLine($"[LoadLevelHandler][TryLoadLevel] Can't load level with index {levelData.CurrentLevel}");
                return false;
            }

            Console.Out.WriteLine($"Loading level {levelData.CurrentLevel}");
            return true;
        }
    }
}