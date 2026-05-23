using Patterns.Strategy.Firearms.Data;
using Patterns.Strategy.ShootingStrategies;

namespace Patterns.Strategy.Firearms
{
    public class Rifle : Firearm
    {
        public Rifle(FirearmData data, IShootingStrategy defaultShootingStrategy) : base(data, defaultShootingStrategy)
        {
        }
    }
}