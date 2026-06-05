using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Spells
{
    public class ShieldSlam : Spell
    {
        public ShieldSlam(float damage) : base(damage)
        {
        }

        protected override void CreateVisitors()
        {
            _mainEffectVisitor = new PhysicalDamageVisitor(_damage);
            _secondaryEffectVisitor = new StunVisitor();
        }
    }
}