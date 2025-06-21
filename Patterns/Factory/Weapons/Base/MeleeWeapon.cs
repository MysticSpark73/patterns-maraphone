using Patterns.Factory.Weapons.Base.Data;

namespace Patterns.Factory.Weapons.Base;

public class MeleeWeapon : IWeapon
{
    protected WeaponStats WeaponStats;

    public MeleeWeapon()
    {
        WeaponStats.DamageType = DamageType.Melee;
        WeaponStats.WeaponType = WeaponType.Melee;
    }
    public string GetStats()
    {
        return WeaponStats.ToString();
    }
}