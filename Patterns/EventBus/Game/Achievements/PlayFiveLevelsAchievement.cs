using Patterns.EventBus.Events;

namespace Patterns.EventBus.Game.Achievements
{
    public class PlayFiveLevelsAchievement : AchievementBase
    {
        private const int TargetLevelNumber = 5;
        
        public PlayFiveLevelsAchievement(string name) : base(name)
        {
            _condition = () => GameData.LevelIndex + 1 >= TargetLevelNumber;
            EventBus.Subscribe<LevelFinishedEvent>(OnLevelFinished);
        }

        private void OnLevelFinished(LevelFinishedEvent eventData)
        {
            TryUnlock();
        }

        public override void Dispose()
        {
            EventBus.Unsubscribe<LevelFinishedEvent>(OnLevelFinished);
        }
    }
}