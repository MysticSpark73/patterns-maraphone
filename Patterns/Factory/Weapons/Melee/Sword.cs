using Patterns.Factory.Weapons.Base;
using Patterns.Factory.Weapons.Base.Data;

namespace Patterns.Factory.Weapons.Melee
{
    public class Sword : MeleeWeapon
    {
        public Sword(int damage, float attackSpeed, WieldType wieldType = WieldType.MainHand,
            DamageType damageType = DamageType.Melee)
        {
            WeaponStats.Damage = damage;
            WeaponStats.AttackSpeed = attackSpeed;
            WeaponStats.WieldType = wieldType;
            WeaponStats.DamageType = damageType;
        }

        public Sword(WeaponStats weaponStats)
        {
            WeaponStats = weaponStats;
        }
    }
}