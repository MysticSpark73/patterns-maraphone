using Patterns.Factory.Weapons.Base;
using Patterns.Factory.Weapons.Base.Data;

namespace Patterns.Factory.Weapons.Ranged
{
    public class Bow : RangedWeapon
    {
        public Bow(int damage, float attackSpeed, WieldType wieldType = WieldType.MainHand,
            DamageType damageType = DamageType.Ranged)
        {
            WeaponStats.Damage = damage;
            WeaponStats.AttackSpeed = attackSpeed;
            WeaponStats.WieldType = wieldType;
            WeaponStats.DamageType = damageType;
        }

        public Bow(WeaponStats weaponStats)
        {
            WeaponStats = weaponStats;
        }
    }
}