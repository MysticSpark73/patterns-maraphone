using Patterns.State.Characters;

namespace Patterns.State.Abilities.Data
{
    public struct AbilityCastData
    {
        public CharacterBase caster;
        public CharacterBase? target;
        public AbilityBase ability;
    }
}