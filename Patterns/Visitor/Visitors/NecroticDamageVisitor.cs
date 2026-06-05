using Patterns.Visitor.Entities;

namespace Patterns.Visitor.Visitors
{
    public class NecroticDamageVisitor : DamageVisitor
    {
        public NecroticDamageVisitor(float damage) : base(damage)
        {
        }

        public override void Visit(Humanoid humanoid)
        {
            DamageDealt += humanoid.TakeDamage(_damage);
        }

        public override void Visit(Undead undead)
        {
            undead.Heal(_damage);
        }

        public override void Visit(Construct construct)
        {
            DamageDealt += construct.TakeDamage(_damage);
        }

        public override void Visit(FireElemental fireElemental)
        {
            DamageDealt += fireElemental.TakeDamage(_damage);
        }
    }
}