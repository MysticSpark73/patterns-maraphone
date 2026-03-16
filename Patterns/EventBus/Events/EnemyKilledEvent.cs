namespace Patterns.EventBus.Events
{
    public class EnemyKilledEvent(int score) : IEvent
    {
        public int score = score;
    }
}