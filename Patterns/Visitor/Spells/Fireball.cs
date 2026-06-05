using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Spells
{
    public class Fireball : Spell
    {
        public Fireball(float damage) : base(damage)
        {
        }

        protected override void CreateVisitors()
        {
            _mainEffectVisitor = new FireDamageVisitor(_damage);
        }
    }
}