using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Spells
{
    public class IceLance : Spell
    {
        public IceLance(float damage) : base(damage)
        {
        }

        protected override void CreateVisitors()
        {
            _mainEffectVisitor = new WaterDamageVisitor(_damage);
        }
    }
}