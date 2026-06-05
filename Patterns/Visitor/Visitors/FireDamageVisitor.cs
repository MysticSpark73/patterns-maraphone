using Patterns.Visitor.Entities;

namespace Patterns.Visitor.Visitors
{
    public class FireDamageVisitor : DamageVisitor
    {
        public FireDamageVisitor(float damage) : base(damage)
        {
        }

        public override void Visit(Humanoid humanoid)
        {
            DamageDealt += humanoid.TakeDamage(_damage);
            humanoid.ApplyBurn();
        }

        public override void Visit(Undead undead)
        {
            DamageDealt += undead.TakeDamage(_damage);
            undead.ApplyBurn();
        }

        public override void Visit(Construct construct)
        {
            DamageDealt += construct.TakeDamage(_damage);
        }

        public override void Visit(FireElemental fireElemental)
        {
            Console.Out.WriteLine($"{fireElemental.GetType().Name} is immune to fire damage!");
        }
    }
}