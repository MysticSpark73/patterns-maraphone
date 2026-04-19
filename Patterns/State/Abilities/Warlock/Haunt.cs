using Patterns.State.Abilities.Data;
using Patterns.State.Characters;

namespace Patterns.State.Abilities.Warlock
{
    public class Haunt : AbilityBase, ICancelable, IInterruptable
    {
        public Haunt(AbilityData data, GlobalCooldownManager cooldownManager) : base(data, cooldownManager)
        {
        }
        
        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Interrupt()
        {
            throw new NotImplementedException();
        }
    }
}