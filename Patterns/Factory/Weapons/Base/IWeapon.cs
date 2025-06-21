namespace Patterns.Factory.Weapons.Base;

public interface IWeapon
{
    public virtual string GetStats()
    {
        return string.Empty;
    }

}