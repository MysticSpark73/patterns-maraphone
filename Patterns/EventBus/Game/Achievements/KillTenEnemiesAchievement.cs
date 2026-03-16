using Patterns.EventBus.Events;

namespace Patterns.EventBus.Game.Achievements
{
    public class KillTenEnemiesAchievement : AchievementBase
    {
        private const int EnemiesToKill = 10;
        private int _enemiesKilled = 0;
        
        public KillTenEnemiesAchievement(string name) : base(name)
        {
            _condition = () => _enemiesKilled >= EnemiesToKill;
            
            EventBus.Subscribe<EnemyKilledEvent>(OnEnemyKilled);
        }

        private void OnEnemyKilled(EnemyKilledEvent eventData)
        {
            _enemiesKilled++;
            TryUnlock();
        }

        public override void Dispose()
        {
            EventBus.Unsubscribe<EnemyKilledEvent>(OnEnemyKilled);
        }
    }
}