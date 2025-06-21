using Patterns.Factory.Weapons.Base;
using Patterns.Factory.Weapons.Base.Data;
using Patterns.Factory.Weapons.Melee;

namespace Patterns.Factory.Specific;

public class SwordsFactory : MeleeWeaponFactory
{
    /// <summary>
    /// Workaround. Should be used instead of common Create() method due to the lack of control over initial variables!
    /// </summary>
    /// <returns>Sword</returns>
    public IWeapon CreateAdapterMethod(int damage, float attackSpeed, WieldType wieldType = WieldType.MainHand,
        DamageType damageType = DamageType.Melee)
    {
        return new Sword(damage, attackSpeed, wieldType, damageType);
    }
}