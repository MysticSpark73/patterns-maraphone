using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Spells
{
    public class CullLightning : Spell
    {
        public CullLightning(float damage) : base(damage)
        {
        }

        protected override void CreateVisitors()
        {
            _mainEffectVisitor = new ElectricityDamageVisitor(_damage);
        }
    }
}