using Patterns.Strategy.Firearms.Data;

namespace Patterns.Strategy.ShootingStrategies
{
    public interface IShootingStrategy
    {
        void Shoot(FirearmData data, ref int bullets);
    }
}