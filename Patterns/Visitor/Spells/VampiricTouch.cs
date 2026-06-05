using Patterns.Visitor.Entities.Interfaces;
using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Spells
{
    public class VampiricTouch : Spell
    {
        public VampiricTouch(float damage) : base(damage)
        {
        }

        protected override void CreateVisitors()
        {
            _mainEffectVisitor = new NecroticDamageVisitor(_damage);
        }

        public override void Cast(IVisitable caster, List<IVisitable> targets)
        {
            base.Cast(caster, targets);

            DamageVisitor? damageVisitor = _mainEffectVisitor as DamageVisitor;
            
            if (damageVisitor == null) return;

            if (caster is IHealable healable) healable.Heal(damageVisitor.DamageDealt);

            damageVisitor.ResetDamageData();
        }
    }
}