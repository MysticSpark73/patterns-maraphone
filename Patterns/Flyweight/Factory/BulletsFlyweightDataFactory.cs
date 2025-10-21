using System.Collections.Generic;
using Patterns.Flyweight.Bullets;

namespace Patterns.Flyweight.Factory
{
    public class BulletsFlyweightDataFactory
    {
        private readonly Dictionary<BulletType, BulletFlyweightData> _flyweightData = new ()
        {
            {BulletType.Pistol, new BulletFlyweightData(1.0f, 10, "Sprites/Bullets/Pistol")},
            {BulletType.Rifle, new BulletFlyweightData(1.5f, 15, "Sprites/Bullets/Rifle")},
            {BulletType.SniperRifle, new BulletFlyweightData(4.5f, 30, "Sprites/Bullets/SniperRifle")},
            {BulletType.Revolver, new BulletFlyweightData(2.0f, 5, "Sprites/Bullets/Revolver")},
            {BulletType.Shotgun, new BulletFlyweightData(.25f, 3, "Sprites/Bullets/Shotgun")},
            {BulletType.Rocket, new BulletFlyweightData(15.0f, 1, "Sprites/Bullets/Rocket", DamageType.Explosion)},
            {BulletType.Silver, new BulletFlyweightData(1.0f, 10, "Sprites/Bullets/Silver", DamageType.Silver)},
        };
        
        public BulletFlyweightData? GetData(BulletType type)
        {
            if (_flyweightData.ContainsKey(type))
            {
                return _flyweightData[type];
            }

            return null;
        }
    }
}