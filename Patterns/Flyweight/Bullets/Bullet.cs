using System;
using System.Numerics;

namespace Patterns.Flyweight.Bullets
{
    public class Bullet
    {
        private Vector3 _position;
        private Vector3 _velocity;
        private Quaternion _rotation;
        private BulletType _bulletType;
        private BulletFlyweightData _bulletFlyweight;

        public Bullet(Vector3 position, Vector3 velocity, Quaternion rotation, BulletType bulletType, BulletFlyweightData bulletFlyweight)
        {
            _position = position;
            _velocity = velocity;
            _rotation = rotation;
            _bulletType = bulletType;
            _bulletFlyweight = bulletFlyweight;
            
            Render();
        }

        public void Shoot(Vector3 direction)
        {
            _velocity = direction * _bulletFlyweight.Speed;
        }

        public void UpdatePosition(float delta)
        {
            _position += _velocity * delta;
        }

        public void Hit()
        {
            _velocity = Vector3.Zero;
            Console.WriteLine($"Bullet {_bulletType} hit the target and were destroyed");
        }

        public (float, DamageType) GetDamage() => (_bulletFlyweight.Damage, _bulletFlyweight.DamageType);

        private void Render()
        {
            Console.Out.WriteLine($"Bullet {_bulletType} is rendered with sprite {_bulletFlyweight.SpritePath}");
        }
    }
}