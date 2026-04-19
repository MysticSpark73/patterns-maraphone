using Patterns.State.Abilities;
using Patterns.State.Abilities.Data;
using Patterns.State.Abilities.Warlock;
using Patterns.State.Characters;

namespace Patterns.State.Classes
{
    public sealed class WarlockClass : ClassBase
    {
        public WarlockClass(GlobalCooldownManager globalCooldownManager) : base(globalCooldownManager)
        {
            CreateAbilities();
        }

        protected override void CreateAbilities()
        {
            _abilities = new List<AbilityBase>();
            
            AbilityData? corruptionData = AbilityDatabase.GetAbilityData(typeof(Corruption));
            if (corruptionData != null)
            {
                _abilities.Add(new Corruption(corruptionData, _globalCooldownManager));
            }

            AbilityData? drainSoulData = AbilityDatabase.GetAbilityData(typeof(DrainSoul));
            if (drainSoulData != null)
            {
                _abilities.Add(new DrainSoul(drainSoulData, _globalCooldownManager));
            }

            AbilityData? hauntData = AbilityDatabase.GetAbilityData(typeof(Haunt));
            if (hauntData != null)
            {
                _abilities.Add(new Haunt(hauntData, _globalCooldownManager));
            }

            AbilityData? malevolenceData = AbilityDatabase.GetAbilityData(typeof(Malevolence));
            if (malevolenceData != null)
            {
                _abilities.Add(new Malevolence(malevolenceData, _globalCooldownManager));
            }
        }
    }
}