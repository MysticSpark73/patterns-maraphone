using Patterns.State.Extensions;

namespace Patterns.State.Abilities
{
    public class LocalCooldownManager : ICooldownManager
    {
        public bool IsOnCooldown => _isOnCooldown;
        
        private bool _isOnCooldown;
        private float _delay;
        private CancellationTokenSource? _cancellationTokenSource;

        public LocalCooldownManager(float delay)
        {
            _delay = delay;
        }

        public void StartCooldownTimer()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            CooldownTimerAsync(_cancellationTokenSource.Token).Forget();
        }

        private async Task CooldownTimerAsync(CancellationToken cancellationToken)
        {
            _isOnCooldown = true;
            try
            {
                await Task.Delay((int)(_delay * 1000), cancellationToken);
            }
            catch (OperationCanceledException e)
            {
                Console.Out.WriteLine($"Local cooldown timer was cancelled! Error: {e.Message}");
            }
            finally
            {
                _isOnCooldown = false;
            }
        }

        public void Dispose()
        {
            if (_cancellationTokenSource != null && _cancellationTokenSource.Token.CanBeCanceled)
            {
                _cancellationTokenSource.Cancel();
            }
            
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
}