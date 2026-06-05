using Patterns.Visitor.Entities;

namespace Patterns.Visitor.Visitors
{
    public class ElectricityDamageVisitor : DamageVisitor
    {
        private const int ConstructDamageMultiplier = 2;
        
        public ElectricityDamageVisitor(float damage) : base(damage)
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
            DamageDealt += construct.TakeDamage(_damage * ConstructDamageMultiplier);
            construct.ApplyStun();
        }

        public override void Visit(FireElemental fireElemental)
        {
            DamageDealt += fireElemental.TakeDamage(_damage);
        }
    }
}