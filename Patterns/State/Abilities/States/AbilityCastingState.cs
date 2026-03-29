namespace Patterns.State.Abilities.States
{
    public class AbilityCastingState : AbilityCastStateBase
    {
        private Task _castingTask;
        private CancellationTokenSource _cancellationTokenSource;

        public AbilityCastingState(AbilityBase ability) : base(ability)
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public override void Cast()
        {
            //todo: do nothing
        }

        public override void Cancel()
        {
            CancelCast();
            //todo: go to ReadyState
        }

        public override void Interrupt()
        {
            //todo: go to CooldownState
        }

        public override void Channel()
        {
            //do nothing
        }

        public override void Enter()
        {
            StartCast();
        }

        public override void Exit()
        {
            CancelCast();
        }

        private void StartCast()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _castingTask = CastTask(_cancellationTokenSource.Token);
            try
            {
                _castingTask.Start();
            }
            catch (TaskCanceledException e)
            {
                //todo: go cooldown if interrupted and to ready if cancelled
            }
        }

        private async Task CastTask(CancellationToken cancellationToken)
        {
            await Task.Delay(500, cancellationToken);
            //todo: go to channel/cooldown state
        }

        private void CancelCast()
        {
            if (_cancellationTokenSource != null && _cancellationTokenSource.Token.CanBeCanceled)
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}