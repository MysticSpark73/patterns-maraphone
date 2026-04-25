using Patterns.State.Abilities.Data;
using Patterns.State.Characters;

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

        public override async void OnCast()
        {
            base.OnCast();

            if (CanDealDamage)
            {
                if (Target == null) return;
                
                Target.OnDie += OnTargetDead;
                Target.TryApplyEffect(EffectType.Corruption);
                Target.TakeDamage(DamageOnCast);
                Console.Out.WriteLine($"{Target?.GetType()} took {DamageOnCast} damage from {GetType()} corruption on cast");
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

            /*_cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await SpellEffectTask(_cancellationTokenSource.Token);
            }
            catch (OperationCanceledException e)
            {
                _timeSpent = 0;

                if (Target == null) return;
                Target.TryRemoveEffect(EffectType.Corruption);
            }*/
            
            StartEffect();
        }

        private async Task SpellEffectTask(CancellationToken cancellationToken)
        {
            while (_timeSpent <= (int) (_data.duration.value.Value * 1000))
            {
                await Task.Delay(TickSpeed, cancellationToken);
                _timeSpent += TickSpeed;

                if (CanDealDamage && Target != null)
                {
                    float damage = DamagePerTick * (Target.IsEffectActive(EffectType.Haunt) ? HauntMultiplier : 1);
                    Target.TakeDamage(damage);
                    Console.Out.WriteLine($"{Target?.GetType()} took {damage} damage from {GetType()}");
                }
                else
                {
                    Console.Out.WriteLine($"Can't deal damage to null or dead target!");
                    CancelEffect();
                    return;
                }
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

        private void StartEffect()
        {
            _ = RunEffectAsync();
        }

        private async Task RunEffectAsync()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await SpellEffectTask(_cancellationTokenSource.Token);
            }
            catch (OperationCanceledException e)
            {
                _timeSpent = 0;

                if (Target == null) return;
                Target.TryRemoveEffect(EffectType.Corruption);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                throw;
            }
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