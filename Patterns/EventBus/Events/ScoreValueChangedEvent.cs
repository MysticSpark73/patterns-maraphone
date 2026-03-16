namespace Patterns.EventBus.Events
{
    public class ScoreValueChangedEvent(int score) : IEvent
    {
        public int score = score;
    }
}