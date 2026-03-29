namespace Patterns.State.Abilities
{
    public class LocalCooldownManager : ICooldownManager
    {
        public bool IsOnCooldown => _isOnCooldown;
        
        private bool _isOnCooldown;
        private float _delay;

        public LocalCooldownManager(float delay)
        {
            _delay = delay;
        }

        public void StartCooldownTimer()
        {
            _isOnCooldown = true;
            //todo: start cooldown timer
        }
    }
}