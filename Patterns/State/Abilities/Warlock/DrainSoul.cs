using Patterns.State.Abilities.Data;
using Patterns.State.Characters;

namespace Patterns.State.Abilities.Warlock
{
    public class DrainSoul : AbilityBase, ICancelable, IInterruptable, IChannelable
    {

        private AbilityCastData? _castData;
        public DrainSoul(AbilityData data, GlobalCooldownManager cooldownManager) : base(data, cooldownManager)
        {
        }

        public override void OnCast()
        {
            base.OnCast();
            //todo: deal damage every tick while channeling
        }
        
        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }

        public void Channel()
        {
            throw new NotImplementedException();
        }

        public override void OnChannelStart()
        {
            //todo: start channel task
        }

        public override void OnChannelFinish()
        {
            //todo: cancel channel task
        }
    }
}