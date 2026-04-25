using Patterns.State.Abilities.Data;

namespace Patterns.State.Abilities.States
{
    public class AbilityCastingState : AbilityCastStateBase
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private InterruptSource _interruptSource = InterruptSource.None;

        public AbilityCastingState(AbilityBase ability) : base(ability) { }

        public override bool Cast()
        {
            return false;
            //do nothing
        }

        public override void Cancel()
        {
            CancelCast();
        }

        public override void Interrupt()
        {
            CancelCast(InterruptSource.Character);
        }

        public override void Channel()
        {
            //do nothing
        }

        public override void Enter()
        {
            _interruptSource = InterruptSource.None;
            StartCast();
        }

        public override void Exit()
        {
            CancelCast();
        }

        private async void StartCast()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            _ability.OnCastStart();

            if (_ability.IsInstant)
            {
                HandleSuccessFullCast();
            }
            else
            {
                _cancellationTokenSource = new CancellationTokenSource();
                try
                {
                    await CastTask(_cancellationTokenSource.Token);
                }
                catch (TaskCanceledException e)
                {
                    HandleCancelledCast();
                }
            }
        }

        private async Task CastTask(CancellationToken cancellationToken)
        {
            await Task.Delay((int) (_ability.CastTime.value.Value * 1000), cancellationToken);
            HandleSuccessFullCast();
        }

        private void CancelCast(InterruptSource interruptSource = InterruptSource.Self)
        {
            if (_cancellationTokenSource != null && _cancellationTokenSource.Token.CanBeCanceled)
            {
                _interruptSource = interruptSource;
                _cancellationTokenSource.Cancel();
            }
            
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private void HandleCancelledCast()
        {
            switch (_interruptSource)
            {
                case InterruptSource.Self:
                    _ability.ChangeState(StateType.ReadyState);
                    break;
                case InterruptSource.Character:
                case InterruptSource.Effect:
                    _ability.StartCooldown();
                    _ability.ChangeState(StateType.ReadyState);
                    break;
                default:
                    Console.Out.WriteLine("Ability cast was interrupted by unknown source!");
                    break;
            }
        }

        private void HandleSuccessFullCast()
        {
            if (_ability.IsChannelable)
            {
                _ability.ChangeState(StateType.ChannelingState);
            }
            else
            {
                _ability.StartCooldown();
                _ability.ChangeState(StateType.ReadyState);
            }
            _ability.OnCast();
        }
    }
}