using Patterns.State.Abilities.Data;
using Patterns.State.Characters;
using Patterns.State.Extensions;

namespace Patterns.State.Abilities.Warlock
{
    public class Malevolence : AbilityBase
    {

        private CancellationTokenSource _cancellationTokenSource;
        
        public Malevolence(AbilityData data, GlobalCooldownManager cooldownManager) : base(data, cooldownManager)
        {
        }

        public override void OnCast()
        {
            base.OnCast();
            
            if (Caster == null || !Caster.IsAlive)
            {
                Console.Out.WriteLine("Can't apply effect to null or dead target!");
                return;
            }
            
            CancelEffect();

            _cancellationTokenSource = new CancellationTokenSource();
            Caster.OnDie += OnCasterDied;

            try
            {
                SpellEffectTask(_cancellationTokenSource.Token).Forget();
            }
            catch (OperationCanceledException e)
            {
                OnEffectCancelled();
            }

        }

        private void OnCasterDied()
        {
            OnEffectCancelled();
        }

        public override void Dispose()
        {
            base.Dispose();
            if (Caster == null) return;

            Caster.OnDie -= OnCasterDied;
        }

        private async Task SpellEffectTask(CancellationToken cancellationToken)
        {
            Caster?.TryApplyEffect(EffectType.Malevolence);
            Console.Out.WriteLine("IDK your spell power is increased I guess");
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

        private void OnEffectCancelled()
        {
            Caster?.TryRemoveEffect(EffectType.Malevolence);
        }
    }
}