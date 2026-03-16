namespace Patterns.EventBus.Events
{
    public struct LevelFinishedEvent(int level) : IEvent
    {
        public int level = level;
    }
}