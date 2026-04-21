using Patterns.State.Abilities.Data;
using Patterns.State.Characters;

namespace Patterns.State.Abilities.Warlock
{
    public class Malevolence : AbilityBase
    {
        public Malevolence(AbilityData data, GlobalCooldownManager cooldownManager) : base(data, cooldownManager)
        {
        }
    }
}