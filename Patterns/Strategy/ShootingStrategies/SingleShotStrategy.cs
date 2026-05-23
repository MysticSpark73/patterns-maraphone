using Patterns.Strategy.Firearms.Data;

namespace Patterns.Strategy.ShootingStrategies
{
    public class SingleShotStrategy : IShootingStrategy
    {
        public void Shoot(FirearmData data, ref int bullets)
        {
            if (bullets == 0)
            {
                Console.Out.WriteLine("*click*");
                return;
            }
            
            bullets--;
            Console.Out.WriteLine($"Single shot was fired! ({bullets})");
        }
    }
}