using Patterns.Strategy.Firearms.Data;
using Patterns.Strategy.ShootingStrategies;

namespace Patterns.Strategy.Firearms
{
    public class AssaultRifle : Firearm
    {
        protected readonly List<IShootingStrategy> ShootingModes = new()
        {
            new SingleShotStrategy(),
            new BurstShotStrategy(),
            new AutomaticShotStrategy(),
        };

        private int _selectedMode;
        
        public AssaultRifle(FirearmData data, IShootingStrategy defaultShootingStrategy) : base(data, defaultShootingStrategy)
        {
            ShootingStrategy = ShootingModes[_selectedMode];
        }

        public override void SwitchShootingMode()
        {
            _selectedMode = (_selectedMode + 1) % ShootingModes.Count;
            ShootingStrategy = ShootingModes[_selectedMode];
            Console.Out.WriteLine($"Switching shooting mode to {ShootingStrategy.GetType().Name}");
        }
    }
}