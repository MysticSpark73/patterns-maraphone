using Patterns.State.Abilities.Data;
using Patterns.State.Characters;
using Patterns.State.Extensions;

namespace Patterns.State.Abilities.Warlock
{
    public class Haunt : AbilityBase, ICancelable, IInterruptable
    {
        private const int DamageOnCast = 720;

        private CancellationTokenSource _cancellationTokenSource;
        
        public Haunt(AbilityData data, GlobalCooldownManager cooldownManager) : base(data, cooldownManager)
        {
        }

        public override void OnCast()
        {
            base.OnCast();

            if (CanDealDamage)
            {
                if (Target == null) return;

                Target.OnDie += OnTargetDied;
                Target.TryApplyEffect(EffectType.Haunt);
                Target.TakeDamage(DamageOnCast);
                Console.Out.WriteLine($"{Target.GetType()} took {DamageOnCast} from {GetType()}");
            }
            else
            {
                Console.Out.WriteLine($"Target is already dead!");
                return;
            }

            CancelEffect();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                SpellEffectTask(_cancellationTokenSource.Token).Forget();
            }
            catch (Exception e)
            {
                OnEffectCancelled();
            }
        }

        public void Cancel()
        {
            _state.Cancel();
        }

        public void Interrupt()
        {
            _state.Interrupt();
        }

        private async Task SpellEffectTask(CancellationToken cancellationToken)
        {
            await Task.Delay((int)(_data.duration.value.Value * 1000), cancellationToken);
            
            OnEffectCancelled();
        }

        private void CancelEffect()
        {
            if (_cancellationTokenSource != null && _cancellationTokenSource.Token.CanBeCanceled)
            {
                _cancellationTokenSource.Cancel();
            }
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private void OnTargetDied()
        {
            CancelEffect();
        }

        private void OnEffectCancelled()
        {
            if (Target == null) return;

            Target.TryRemoveEffect(EffectType.Haunt);
        }

        public override void Dispose()
        {
            base.Dispose();

            OnEffectCancelled();
        }
    }
}