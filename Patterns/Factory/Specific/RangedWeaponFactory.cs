using Patterns.Factory.Base;
using Patterns.Factory.Weapons.Base;

namespace Patterns.Factory.Specific
{
    public class RangedWeaponFactory : FactoryBase
    {
        public override IWeapon Create()
        {
            return new RangedWeapon();
        }
    }
}