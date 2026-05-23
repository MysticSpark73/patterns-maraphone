using Patterns.Common;
using Patterns.Strategy.Firearms;
using Patterns.Strategy.ShootingStrategies;

namespace Patterns.Strategy
{
    public class StrategyMain : IProgram
    {
        private Pistol _pistol;
        private AssaultRifle _assaultRifle;
        private Rifle _rifle;
        private Shotgun _shotgun;
        
        public void Run(params object[]? args)
        {
            CreateArsenal();
            FireShots();
        }

        private void CreateArsenal()
        {
            var pistolData = FirearmDataProvider.GetData<Pistol>();
            if (!pistolData.HasValue)
            {
                Console.Out.WriteLine("Failed to retrieve FirearmData for Pistol!");
            }
            else
            {
                _pistol = new Pistol(pistolData.Value, new SingleShotStrategy());
            }

            var assaultRifleData = FirearmDataProvider.GetData<AssaultRifle>();
            if (!assaultRifleData.HasValue)
            {
                Console.Out.WriteLine("Failed to retrieve FirearmData for AssaultRifle!");
            }
            else
            {
                _assaultRifle = new AssaultRifle(assaultRifleData.Value, new SingleShotStrategy());
            }

            var rifleData = FirearmDataProvider.GetData<Rifle>();
            if (!rifleData.HasValue)
            {
                Console.Out.WriteLine("Failed to retrieve FirearmData for Rifle!");
            }
            else
            {
                _rifle = new Rifle(rifleData.Value, new SingleShotStrategy());
            }

            var shotgunData = FirearmDataProvider.GetData<Shotgun>();
            if (!shotgunData.HasValue)
            {
                Console.Out.WriteLine("Failed to retrieve FirearmData for Shotgun!");
            }
            else
            {
                _shotgun = new Shotgun(shotgunData.Value, new ShotgunShotStrategy());
            }
        }

        private void FireShots()
        {
            Console.Out.WriteLine("=======Pistol=======");
            _pistol.Shoot();
            _pistol.Shoot();
            _pistol.Shoot();
            _pistol.Shoot();
            _pistol.Shoot();
            _pistol.Shoot();
            _pistol.Shoot();
            _pistol.Shoot();
            _pistol.Reload();
            _pistol.Shoot();
            Console.Out.WriteLine("=======Assault Rifle=======");
            _assaultRifle.Shoot();
            _assaultRifle.Shoot();
            _assaultRifle.Shoot();
            _assaultRifle.SwitchShootingMode();
            _assaultRifle.Shoot();
            _assaultRifle.Shoot();
            _assaultRifle.SwitchShootingMode();
            _assaultRifle.Shoot();
            _assaultRifle.Shoot();
            Console.Out.WriteLine("=======Rifle=======");
            _rifle.Shoot();
            _rifle.Shoot();
            _rifle.Shoot();
            _rifle.Shoot();
            _rifle.Shoot();
            _rifle.Shoot();
            Console.Out.WriteLine("=======Shotgun=======");
            _shotgun.Shoot();
            _shotgun.Shoot();
            _shotgun.Shoot();
        }
    }
}