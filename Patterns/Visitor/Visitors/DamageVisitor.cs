using Patterns.Visitor.Entities;

namespace Patterns.Visitor.Visitors
{
    public abstract class DamageVisitor : IVisitor
    {
        protected readonly float _damage;
        public float DamageDealt { get; protected set; }

        public void ResetDamageData() => DamageDealt = 0;

        protected DamageVisitor(float damage)
        {
            _damage = damage;
        }

        public abstract void Visit(Humanoid humanoid);

        public abstract void Visit(Undead undead);

        public abstract void Visit(Construct construct);

        public abstract void Visit(FireElemental fireElemental);
    }
}