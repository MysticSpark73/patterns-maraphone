using Patterns.State.Abilities;
using Patterns.State.Characters;

namespace Patterns.State.Classes
{
    public abstract class ClassBase : IDisposable
    {
        protected List<AbilityBase> _abilities;
        protected GlobalCooldownManager _globalCooldownManager;

        protected ClassBase(GlobalCooldownManager globalCooldownManager)
        {
            _globalCooldownManager = globalCooldownManager;
        }

        protected abstract void CreateAbilities();

        public AbilityBase? GetSpell(string name)
        {
            foreach (var ability in _abilities)
            {
                if (string.CompareOrdinal(name, ability.Name) == 0)
                {
                    return ability;
                }
            }

            return null;
        }

        public void Dispose()
        {
            _abilities.ForEach(i => i.Dispose());
        }
    }
}