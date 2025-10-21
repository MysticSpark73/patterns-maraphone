namespace Patterns.Flyweight.Bullets
{
    public class BulletFlyweightData
    {
        public float Damage { get; }
        public int Speed { get; }
        public string SpritePath { get; }
        public DamageType DamageType { get; }

        public BulletFlyweightData(float damage, int speed, string spritePath, DamageType damageType = DamageType.Default)
        {
            Damage = damage;
            Speed = speed;
            SpritePath = spritePath;
            DamageType = damageType;
        }
    }
}