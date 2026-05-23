using Patterns.Strategy.Firearms.Data;
using Patterns.Strategy.ShootingStrategies;

namespace Patterns.Strategy.Firearms
{
    public class Shotgun : Firearm
    {
        public Shotgun(FirearmData data, IShootingStrategy defaultShootingStrategy) : base(data, defaultShootingStrategy)
        {
        }
    }
}