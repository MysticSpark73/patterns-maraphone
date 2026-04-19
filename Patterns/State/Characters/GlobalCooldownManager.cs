namespace Patterns.State.Characters
{
    public class GlobalCooldownManager : ICooldownManager
    {
        public bool IsOnCooldown => _isOnCooldown;
        public const float CooldownValue = 1.5f;

        private bool _isOnCooldown;
        private CancellationTokenSource? _cancellationTokenSource;
        private Task _cooldownTask;

        public void StartCooldownTimer()
        {
            if (_isOnCooldown)
            {
                Console.Out.WriteLine("Reset GCD Time!");
                CancelCooldown();
                StartCooldownTimer();
            }
            else
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _cooldownTask = CooldownTask(_cancellationTokenSource.Token);

                try
                {
                    _cooldownTask.Start();
                }
                catch (OperationCanceledException e)
                {
                    Console.Out.WriteLine($"Global cooldown timer was cancelled! Error: {e.Message}");
                }
                finally
                {
                    _isOnCooldown = false;
                }
            }
        }

        private async Task CooldownTask(CancellationToken cancellationToken)
        {
            _isOnCooldown = true;
            await Task.Delay((int)(CooldownValue * 1000), cancellationToken);
            _isOnCooldown = false;
        }

        private void CancelCooldown()
        {
            if (_cancellationTokenSource != null && _cancellationTokenSource.Token.CanBeCanceled)
            {
                _cancellationTokenSource.Cancel();
            }
            
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        public void Dispose()
        {
            CancelCooldown();
        }
    }
}