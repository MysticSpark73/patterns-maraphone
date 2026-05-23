
using Patterns.Strategy.Firearms.Data;
using Patterns.Strategy.ShootingStrategies;

namespace Patterns.Strategy.Firearms
{
    public class Pistol : Firearm
    {
        public Pistol(FirearmData data, IShootingStrategy defaultShootingStrategy) : base(data, defaultShootingStrategy)
        {
        }
    }
}