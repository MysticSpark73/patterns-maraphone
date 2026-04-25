using Patterns.State.Abilities.Data;
using Patterns.State.Characters;

namespace Patterns.State.Abilities.Warlock
{
    public class DrainSoul : AbilityBase, ICancelable, IInterruptable, IChannelable
    {
        private const int TickSpeed = 500;
        private const int DamagePerTick = 13;
        
        private CancellationTokenSource? _cancellationTokenSource;
        private Task? _effectTask;
        private int _timeSpent = 0;
        
        public DrainSoul(AbilityData data, GlobalCooldownManager cooldownManager) : base(data, cooldownManager)
        {
        }

        public override void OnCast()
        {
            base.OnCast();
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

        public void Channel()
        {
            //do nothing?
        }

        public override void OnChannelStart()
        {
            if (CanDealDamage)
            {
                if (Target  == null) return;

                Target.OnDie += OnTargetDied;
            }
            else
            {
                Console.Out.WriteLine($"Target is already dead!");
                return;
            }

            if (_timeSpent > 0)
            {
                _timeSpent = 0;
                Console.Out.WriteLine("DrainSoul channel timer has been reset!");
                return;
            }
            
            CancelEffect();
            
            _cancellationTokenSource = new CancellationTokenSource();
            _effectTask = SpellEffectTask(_cancellationTokenSource.Token);

            try
            {
                _effectTask.Start();
            }
            catch (OperationCanceledException e)
            {
                _timeSpent = 0;
            }
        }

        public override void OnChannelFinish()
        {
            CancelEffect();
        }

        private async Task SpellEffectTask(CancellationToken cancellationToken)
        {
            while (_timeSpent <= (int) (_data.channelDuration.value.Value * 1000))
            {
                await Task.Delay(TickSpeed, cancellationToken);
                _timeSpent += TickSpeed;

                if (CanDealDamage && Target != null)
                {
                    Target.TakeDamage(DamagePerTick * GetDamageModifier());
                    Console.Out.WriteLine($"{Target?.GetType()} took {DamagePerTick * GetDamageModifier()} damage from {GetType()}");
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

        private int GetDamageModifier()
        {
            if (Target == null) return 1;

            return Target.CurrentHealth / Target.MaxHealth <= .2f ? 2 : 1;
        }

        private void OnTargetDied()
        {
            CancelEffect();
        }

        public override void Dispose()
        {
            base.Dispose();
            if (Target != null)
            {
                Target.OnDie -= OnTargetDied;
            }
        }
    }
}