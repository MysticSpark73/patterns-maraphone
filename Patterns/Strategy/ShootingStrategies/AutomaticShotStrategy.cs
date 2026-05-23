using Patterns.Strategy.Firearms.Data;

namespace Patterns.Strategy.ShootingStrategies
{
    public class AutomaticShotStrategy : IShootingStrategy
    {
        public void Shoot(FirearmData data, ref int bullets)
        {
            if (bullets == 0)
            {
                Console.Out.WriteLine("*click*");
                return;
            }

            for (int i = bullets; i > 0; i--)
            {
                Console.Out.WriteLine($"Automatic shot was fired! ({i})");
            }

            bullets = 0;
        }
    }
}