using Patterns.State.Abilities.Data;
using Patterns.State.Characters;
using Patterns.State.Extensions;

namespace Patterns.State.Abilities.Warlock
{
    public class Corruption : AbilityBase, ICancelable, IInterruptable
    {
        private const int TickSpeed = 500;
        private const int DamagePerTick = 13;
        private const int DamageOnCast = 30;
        
        //hardcoded value for the sake of simplicity.
        //I'm not going to implement whole buffs/debuffs tracker just for this one interaction, sorry...
        private const float HauntMultiplier = 1.12f;
        
        private CancellationTokenSource? _cancellationTokenSource;
        private int _timeSpent = 0;
        
        public Corruption(AbilityData data, GlobalCooldownManager cooldownManager) : base(data, cooldownManager)
        {
        }

        public void Cancel()
        {
            _state.Cancel();
            CancelEffect();
        }

        public void Interrupt()
        {
            _state.Interrupt();
            CancelEffect();
        }

        public override void OnCast()
        {
            base.OnCast();

            if (CanDealDamage)
            {
                if (Target == null) return;

                Target.OnDie += OnTargetDead;
                Target.TryApplyEffect(EffectType.Corruption);
                Target.TakeDamage(DamageOnCast);
                Console.Out.WriteLine(
                    $"{Target?.GetType().Name} took {DamageOnCast} damage from {GetType().Name} corruption on cast");
            }
            else
            {
                Console.Out.WriteLine($"Target is already dead!");
                return;
            }

            if (_timeSpent > 0)
            {
                _timeSpent = 0;
                Console.Out.WriteLine("Corruption time has been reset");
                return;
            }

            CancelEffect();

            _cancellationTokenSource = new CancellationTokenSource();
            SpellEffectTask(_cancellationTokenSource.Token).Forget();
        }

        private async Task SpellEffectTask(CancellationToken cancellationToken)
        {
            try
            {
                while (_timeSpent <= (int) (_data.duration.value.Value * 1000))
                {
                    await Task.Delay(TickSpeed, cancellationToken);
                    _timeSpent += TickSpeed;

                    if (CanDealDamage && Target != null)
                    {
                        float damage = DamagePerTick * (Target.IsEffectActive(EffectType.Haunt) ? HauntMultiplier : 1);
                        Target.TakeDamage(damage);
                        Console.Out.WriteLine($"{Target?.GetType().Name} took {damage} damage from {GetType().Name}");
                    }
                    else
                    {
                        Console.Out.WriteLine($"Can't deal damage to null or dead target!");
                        CancelEffect();
                        return;
                    }
                }
            }
            catch (OperationCanceledException e)
            {
                _timeSpent = 0;

                if (Target == null) return;
                Target.TryRemoveEffect(EffectType.Corruption);
            }
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

        public override void Dispose()
        {
            if (Target != null)
            {
                Target.OnDie -= OnTargetDead;
            }
            base.Dispose();
        }

        private void OnTargetDead()
        {
            Console.Out.WriteLine("Target has died!");
            if (Target != null)
            {
                Target.OnDie -= OnTargetDead;
            }
        }
    }
}