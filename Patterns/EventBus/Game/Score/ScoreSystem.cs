using Patterns.EventBus.Events;

namespace Patterns.EventBus.Game.Score
{
    public class ScoreSystem : IDisposable
    {
        private int _score = 0;

        public ScoreSystem()
        {
            EventBus.Subscribe<EnemyKilledEvent>(OnEnemyKilled);
        }

        private void OnEnemyKilled(EnemyKilledEvent eventData)
        {
            _score += eventData.score;
            EventBus.Invoke(new ScoreValueChangedEvent(_score));
        }

        public void Dispose()
        {
            EventBus.Unsubscribe<EnemyKilledEvent>(OnEnemyKilled);
        }
    }
}