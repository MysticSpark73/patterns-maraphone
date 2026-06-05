using Patterns.Visitor.Entities;

namespace Patterns.Visitor.Visitors
{
    public class WaterDamageVisitor : DamageVisitor
    {
        private const int FireDamageMultiplier = 2;

        public WaterDamageVisitor(float damage) : base(damage)
        {
        }

        public override void Visit(Humanoid humanoid)
        {
            DamageDealt += humanoid.TakeDamage(_damage);
        }

        public override void Visit(Undead undead)
        {
            DamageDealt += undead.TakeDamage(_damage);
        }

        public override void Visit(Construct construct)
        {
            DamageDealt += construct.TakeDamage(_damage);
        }

        public override void Visit(FireElemental fireElemental)
        {
            DamageDealt += fireElemental.TakeDamage(_damage * FireDamageMultiplier);
        }
    }
}