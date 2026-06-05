using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Spells
{
    public class PoisonCloud : Spell
    {
        public PoisonCloud(float damage) : base(damage)
        {
        }

        protected override void CreateVisitors()
        {
            _mainEffectVisitor = new PoisonDamageVisitor(_damage);
        }
    }
}