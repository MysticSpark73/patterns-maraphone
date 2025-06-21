using Patterns.Factory.Weapons.Base;

namespace Patterns.Factory.Base;

public abstract class FactoryBase
{
    public abstract IWeapon Create();

    public virtual string PrintStats()
    {
        IWeapon weapon = Create();
        return "Weapon Stats : \n " + weapon.GetStats();
    }
}