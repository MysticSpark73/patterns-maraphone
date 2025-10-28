using System;
using Patterns.ChainOfResponsibility.Data;

namespace Patterns.ChainOfResponsibility.Handlers
{
    public class LoadLevelHandler : HandlerBase
    {
        public override bool Handle(SaveData saveData)
        {
            if (!TryLoadLevel(saveData)) return false;
            
            return base.Handle(saveData);
        }

        private bool TryLoadLevel(SaveData saveData)
        {
            LevelData levelData = CreateLevelData();
            
            if (levelData.CurrentLevel <0 || levelData.CurrentLevel >= levelData.LevelsCount)
            {
                Console.Out.WriteLine($"[LoadLevelHandler][TryLoadLevel] Can't load level with index {levelData.CurrentLevel}");
                return false;
            }

            Console.Out.WriteLine($"Loading level {levelData.CurrentLevel}");

            saveData.LevelData = levelData;
            return true;
        }

        private LevelData CreateLevelData()
        {
            Console.Out.WriteLine("Loading LevelData...");
            LevelData levelData = new LevelData();
            levelData.CurrentLevel = 1;
            levelData.LevelsCount = 50;
            return levelData;
        }
    }
}