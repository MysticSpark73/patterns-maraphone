using Patterns.State.Abilities.Data;
using Patterns.State.Characters;

namespace Patterns.State.Abilities.Warlock
{
    public class Corruption : AbilityBase, ICancelable, IInterruptable
    {

        private AbilityCastData? _castData = null;
        
        public Corruption(AbilityData data, GlobalCooldownManager cooldownManager) : base(data, cooldownManager)
        {
        }

        public void Cancel()
        {
            _state.Cancel();
        }

        public void Interrupt()
        {
            _state.Interrupt();
        }

        public override void OnCast()
        {
            base.OnCast();
            //todo: apply DoT on the target
        }
    }
}