using Patterns.Factory.Weapons.Base;
using Patterns.Factory.Weapons.Base.Data;
using Patterns.Factory.Weapons.Ranged;

namespace Patterns.Factory.Specific;

public class BowsFactory : RangedWeaponFactory
{
    /// <summary>
    /// Workaround. Should be used instead of common Create() method due to the lack of control over initial variables!
    /// </summary>
    /// <returns>Bow</returns>
    public IWeapon CreateAdapterMethod(int damage, float attackSpeed, WieldType wieldType = WieldType.MainHand,
        DamageType damageType = DamageType.Ranged)
    {
        return new Bow(damage, attackSpeed, wieldType, damageType);
    }
}