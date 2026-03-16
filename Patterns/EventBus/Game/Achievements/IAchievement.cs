namespace Patterns.EventBus.Game.Achievements
{
    public interface IAchievement
    {
        public string Name { get; }
        
        public bool IsUnlocked { get; }

        public void TryUnlock();
    }
}