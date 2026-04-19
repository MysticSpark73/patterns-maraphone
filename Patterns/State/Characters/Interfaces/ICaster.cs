using Patterns.State.Abilities.Data;

namespace Patterns.State.Characters.Interfaces
{
    public interface ICaster
    {
        void CastSpell(AbilityCastData castData);
    }
}