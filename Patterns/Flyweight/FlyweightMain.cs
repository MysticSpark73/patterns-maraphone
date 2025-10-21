using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Patterns.Common;
using Patterns.Flyweight.Bullets;
using Patterns.Flyweight.Factory;

namespace Patterns.Flyweight
{
    public class FlyweightMain : IProgram
    {
        private const float DELTA = .1f;
        public const float SILVER_DAMAGE_COEFFICIENT = 1.5f;
        private const int BULLETS_POOL_SIZE = 10;
        private const int Z_BOUND = 100;
        private const int EXPLOSION_BASE_DISTANCE = 10;
        
        private readonly Vector3 SPAWN_POINT = new Vector3(0, 0, 0);
        private readonly Vector3 SHOOT_DIRECTION = Vector3.UnitZ;
        
        private BulletsFlyweightDataFactory _factory;
        private List<Bullet> _bullets = new();
        private Queue<Bullet> _bulletsToDestroy = new();

        public void Run(object[]? args = null)
        {
            CreateFactory();
            CreateBulletsPool();
            ShootBullets();
            UpdateBullets();
        }

        private void CreateFactory()
        {
            _factory = new BulletsFlyweightDataFactory();
        }

        private void CreateBulletsPool()
        {
            foreach (var bulletType in Enum.GetValues(typeof(BulletType)))
            {
                BulletType type = (BulletType) bulletType;
                for (int i = 0; i < BULLETS_POOL_SIZE; i++)
                {
                    _bullets.Add(new Bullet(SPAWN_POINT, Quaternion.Identity, type,
                        _factory.GetData(type) ??
                        throw new InvalidOperationException($"BulletFlyweightData for type {type} does not exist!")));
                }
            }
        }

        private void ShootBullets()
        {
            foreach (var bullet in _bullets)
            {
                bullet.Shoot(SHOOT_DIRECTION);
            }
        }

        private async void UpdateBullets()
        {
            while (_bullets.Count > 0)
            {
                await Task.Delay((int) DELTA * 1000);
                
                foreach (var bullet in _bullets)
                {
                    bullet.UpdatePosition(DELTA);
                    if (bullet.Position.Z >= Z_BOUND)
                    {
                        bullet.Hit();
                        (float damage, DamageType type) = bullet.GetDamage();
                        TakeDamage(damage, type, bullet.Position);
                        _bulletsToDestroy.Enqueue(bullet);
                    }
                }
                
                ClearQueuedBullets();
            }
        }

        private void TakeDamage(float damage, DamageType type, Vector3 bulletPosition)
        {
            float finalDamage = damage;
            switch (type)
            {
                case DamageType.Default:
                    break;
                case DamageType.Explosion:
                    finalDamage = damage * CalculateExplosionDamageCoefficient(bulletPosition.Z, 
                        Z_BOUND, EXPLOSION_BASE_DISTANCE);
                    break;
                case DamageType.Silver:
                    finalDamage = damage * SILVER_DAMAGE_COEFFICIENT;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            Console.Out.WriteLine($"Damage received : {finalDamage} of type {type}");
        }

        private void ClearQueuedBullets()
        {
            Bullet temp;
            int queueSize = _bulletsToDestroy.Count;
            for (int i = 0; i < queueSize; i++)
            {
                temp = _bulletsToDestroy.Dequeue();
                if (_bullets.Contains(temp))
                {
                    _bullets.Remove(temp);
                }
            }
            _bulletsToDestroy.Clear();
        }

        private float CalculateExplosionDamageCoefficient(float projectilePosition, float hitPosition, int explosionRadius)
        {
            float distance = projectilePosition - hitPosition;
            return MathF.Max(0, 1 - MathF.Pow(distance / explosionRadius, 2));
        }
    }
}