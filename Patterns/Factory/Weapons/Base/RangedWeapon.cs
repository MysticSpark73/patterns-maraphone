using Patterns.Factory.Weapons.Base.Data;

namespace Patterns.Factory.Weapons.Base
{
    public class RangedWeapon : IWeapon
    {
        protected WeaponStats WeaponStats;

        public RangedWeapon()
        {
            WeaponStats.DamageType = DamageType.Ranged;
            WeaponStats.WeaponType = WeaponType.Ranged;
        }

        public string GetStats()
        {
            return WeaponStats.ToString();
        }
    }
}