namespace Patterns.State
{
    public interface ICooldownManager : IDisposable
    {
        public bool IsOnCooldown { get; }

        void StartCooldownTimer();
    }
}