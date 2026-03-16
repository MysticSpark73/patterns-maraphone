namespace Patterns.EventBus.Game.Achievements
{
    public class AchievementBase : IAchievement, IDisposable
    {
        public string Name { get; }
        public bool IsUnlocked { get; private set; }

        protected Func<bool> _condition;

        public AchievementBase(string name)
        {
            Name = name;
        }

        public void TryUnlock()
        {
            if (IsUnlocked) return;
            
            IsUnlocked = _condition();
            if (IsUnlocked)
            {
                Console.Out.WriteLine($"Achievement \"{Name}\" is Unlocked!!!");
            }
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}