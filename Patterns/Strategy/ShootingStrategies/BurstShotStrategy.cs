using Patterns.Strategy.Firearms.Data;

namespace Patterns.Strategy.ShootingStrategies
{
    public class BurstShotStrategy : IShootingStrategy
    {
        public void Shoot(FirearmData data, ref int bullets)
        {
            if (bullets == 0)
            {
                Console.Out.WriteLine("*click*");
                return;
            }

            if (data.burstSize == 0)
            {
                Console.Out.WriteLine("Given firearm does not have burst mode!");
                return;
            }

            for (int i = 0; i < Math.Min(bullets, data.burstSize); i++)
            {
                bullets--;
                Console.Out.WriteLine($"Burst shot was fired! ({bullets})");
            }
        }
    }
}