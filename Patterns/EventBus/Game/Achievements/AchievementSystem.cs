namespace Patterns.EventBus.Game.Achievements
{
    public class AchievementSystem : IDisposable
    {
        private IAchievement[] _achievements;

        public AchievementSystem()
        {
            CreateAchievements();
        }

        public void Dispose()
        {
            foreach (var achievement in _achievements)
            {
                IDisposable? disposable = achievement as IDisposable;
                disposable?.Dispose();
            }
        }

        private void CreateAchievements()
        {
            _achievements = new IAchievement[]
            {
                new PlayFiveLevelsAchievement("First Steps"),
                new KillTenEnemiesAchievement("Kill! Kill! Kill! No time 2 chill!"),
                new ReachHundredScoreAchievement("Path to Glory"),
                new EarnMoneyAchievement("Money! Money! Money!")
            };
        }
    }
}