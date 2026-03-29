using Patterns.State.Characters;

namespace Patterns.State.Abilities.Data
{
    public class AbilityCastData
    {
        public CharacterBase caster;
        public CharacterBase? target;
        public AbilityBase ability;
    }
}