using Patterns.EventBus.Events;

namespace Patterns.EventBus.Game.Achievements
{
    public class ReachHundredScoreAchievement : AchievementBase
    {
        private const int ScoreToReach = 100;
        private int _cachedScore;
        
        public ReachHundredScoreAchievement(string name) : base(name)
        {
            _condition = () => _cachedScore >= ScoreToReach;
            EventBus.Subscribe<ScoreValueChangedEvent>(OnScoreValueChanged);
        }

        private void OnScoreValueChanged(ScoreValueChangedEvent eventData)
        {
            _cachedScore = eventData.score;
            TryUnlock();
        }

        public override void Dispose()
        {
            EventBus.Unsubscribe<ScoreValueChangedEvent>(OnScoreValueChanged);
        }
    }
}