using Patterns.Strategy.Firearms.Data;

namespace Patterns.Strategy.ShootingStrategies
{
    public class ShotgunShotStrategy : IShootingStrategy
    {
        public void Shoot(FirearmData data, ref int bullets)
        {
            if (bullets == 0)
            {
                Console.Out.WriteLine("*click*");
                return;
            }
            
            bullets--;
            Console.Out.WriteLine($"Shotgun shot was fired! ({bullets})");
        }
    }
}