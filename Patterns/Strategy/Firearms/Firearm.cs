using Patterns.Strategy.Firearms.Data;
using Patterns.Strategy.ShootingStrategies;

namespace Patterns.Strategy.Firearms
{
    public abstract class Firearm
    {
        protected IShootingStrategy ShootingStrategy;
        protected FirearmData Data;
        protected int Bullets;
        
        protected Firearm(FirearmData data, IShootingStrategy defaultShootingStrategy)
        {
            Data = data;
            ShootingStrategy = defaultShootingStrategy;
            Bullets = Data.magazineCapacity;
        }

        public virtual void SwitchShootingMode()
        {
            Console.Out.WriteLine($"Can't change mode for {GetType().Name}");
        }

        public void Shoot()
        {
            ShootingStrategy.Shoot(Data, ref Bullets);
        }

        public void Reload()
        {
            Bullets = Data.magazineCapacity;
            Console.Out.WriteLine($"Reloading {GetType().Name}! Bullets = {Bullets}");
        }
    }
}