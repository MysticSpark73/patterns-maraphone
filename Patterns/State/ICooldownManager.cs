namespace Patterns.State
{
    public interface ICooldownManager
    {
        public bool IsOnCooldown { get; }

        void StartCooldownTimer();
    }
}