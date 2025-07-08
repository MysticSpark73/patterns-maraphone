namespace Patterns.Factory.Weapons.Base.Data;

public struct WeaponStats
{
    public int Damage = 0;
    public float AttackSpeed = 1;
    public DamageType DamageType;
    public WieldType WieldType;
    public WeaponType WeaponType;

    public override string ToString()
    {
        string res = "";
        foreach (var field in typeof(WeaponStats).GetFields())
        {
            res += $"{field.Name} : {field.GetValue(this)}\n";
        }

        return res;
    }
}