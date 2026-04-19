using Patterns.State.Abilities.Data;

namespace Patterns.State.Classes
{
    public abstract class ClassBase : IDisposable
    {
        protected AbilityData[] _abilityDatas;

        private void CreateAbilities()
        {
            //todo: create abilities based on abilityDatas
        }

        public void Dispose()
        {
            //todo: dispose all abilities created
        }
    }
}