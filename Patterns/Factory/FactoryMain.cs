using Patterns.Common;
using Patterns.Factory.Specific;
using Patterns.Factory.Weapons.Base;
using Patterns.Factory.Weapons.Base.Data;

namespace Patterns.Factory;

public class FactoryMain : IProgram
{
    private MeleeWeaponFactory _meleeWeaponFactory;
    private RangedWeaponFactory _rangedWeaponFactory;
    private SwordsFactory _swordsFactory;
    private BowsFactory _bowsFactory;

    private IWeapon[] _weapons;

    public void Run(object[]? args = null)
    {
        BuildFactories();
        CreateWeapons();
        PrintWeaponStats();
    }

    private void BuildFactories()
    {
        _meleeWeaponFactory = new MeleeWeaponFactory();
        _rangedWeaponFactory = new RangedWeaponFactory();
        _swordsFactory = new SwordsFactory();
        _bowsFactory = new BowsFactory();
    }

    private void CreateWeapons()
    {
        _weapons = new IWeapon[]
        {
            _meleeWeaponFactory.Create(),
            _rangedWeaponFactory.Create(),
            _swordsFactory.CreateAdapterMethod(2, .33f),
            _swordsFactory.CreateAdapterMethod(4, .28f, damageType: DamageType.Nature),
            _bowsFactory.CreateAdapterMethod(5, .8f),
            _bowsFactory.CreateAdapterMethod(8, 1.2f, damageType: DamageType.Fire)
        };
    }

    private void PrintWeaponStats()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            PrintStats(_weapons[i]);
            Console.WriteLine();
        }
    }

    private void PrintStats(IWeapon weapon)
    {
        Console.WriteLine($"{weapon.GetType()}\n" + weapon.GetStats());
    }
}