using Patterns.Visitor.Entities;

namespace Patterns.Visitor.Visitors
{
    public class PoisonDamageVisitor : DamageVisitor
    {
        public PoisonDamageVisitor(float damage) : base(damage)
        {
        }

        public override void Visit(Humanoid humanoid)
        {
            DamageDealt += humanoid.ApplyPoison(_damage);
        }

        public override void Visit(Undead undead)
        {
            Console.Out.WriteLine($"{undead.GetType().Name} is immune to poison!");
        }

        public override void Visit(Construct construct)
        {
            Console.Out.WriteLine($"{construct.GetType().Name} is immune to poison!");
        }

        public override void Visit(FireElemental fireElemental)
        {
            Console.Out.WriteLine($"{fireElemental.GetType().Name} is immune to poison!");
        }
    }
}