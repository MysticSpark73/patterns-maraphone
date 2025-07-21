using Patterns.Factory.Base;
using Patterns.Factory.Weapons.Base;

namespace Patterns.Factory.Specific
{
    public class MeleeWeaponFactory : FactoryBase
    {
        public override IWeapon Create()
        {
            return new MeleeWeapon();
        }
    }
}