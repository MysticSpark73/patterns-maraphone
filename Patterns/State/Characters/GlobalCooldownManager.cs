namespace Patterns.State.Characters
{
    public class GlobalCooldownManager : ICooldownManager
    {
        public bool IsOnCooldown => _isOnCooldown;

        private bool _isOnCooldown;

        public void StartCooldownTimer()
        {
            _isOnCooldown = true;
            //todo: start task for GCD
        }
    }
}