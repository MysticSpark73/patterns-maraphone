using Patterns.State.Abilities.Data;

namespace Patterns.State.Abilities.States
{
    public class AbilityChannelingState : AbilityCastStateBase
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private Task _channelTask;
        private InterruptSource _interruptSource = InterruptSource.None;
        
        public AbilityChannelingState(AbilityBase ability) : base(ability) { }

        public override bool Cast()
        {
            //do nothing
            return false;
        }

        public override void Cancel()
        {
            CancelChannel();
        }

        public override void Interrupt()
        {
            CancelChannel(InterruptSource.Character);
        }

        public override void Channel()
        {
            //do nothing
        }

        public override void Enter()
        {
            _interruptSource = InterruptSource.None;
            StartChanneling();
        }

        public override void Exit()
        {
            CancelChannel();
        }

        private void StartChanneling()
        {
            if (!_ability.ChannelDuration.IsChannelable)
            {
                Console.Out.WriteLine("Attempting to channel non-channelable ability!");
                _ability.StartCooldown();
                _ability.ChangeState(StateType.ReadyState);
                return;
            }
            
            _ability.OnChannelStart();
            _cancellationTokenSource = new CancellationTokenSource();
            _channelTask = ChannelTask(_cancellationTokenSource.Token);
            
            try
            {
                _channelTask.Start();
            }
            catch (OperationCanceledException e)
            {
                HandleChannelCancelled();
            }
        }

        private async Task ChannelTask(CancellationToken cancellationToken)
        {
            await Task.Delay((int)(_ability.ChannelDuration.value.Value * 1000), cancellationToken);
            HandleChannelFinished();
        }

        private void CancelChannel(InterruptSource interruptSource = InterruptSource.Self)
        {
            if (_cancellationTokenSource != null && _cancellationTokenSource.Token.CanBeCanceled)
            {
                _interruptSource = interruptSource;
                _cancellationTokenSource.Cancel();
            }
            
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private void HandleChannelCancelled()
        {
            _ability.OnChannelFinish();
            _ability.StartCooldown();
            _ability.ChangeState(StateType.ReadyState);
        }

        private void HandleChannelFinished()
        {
            //I mean yeah they're identical I get it. But logically they're different and may result in different behaviours if logic is ever extended.
            _ability.OnChannelFinish();
            _ability.StartCooldown();
            _ability.ChangeState(StateType.ReadyState);
        }
    }
}