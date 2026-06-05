using Patterns.Visitor.Entities.Interfaces;
using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Spells
{
    public abstract class Spell
    {
        protected IVisitor _mainEffectVisitor;
        protected IVisitor? _secondaryEffectVisitor;
        protected readonly float _damage;

        protected abstract void CreateVisitors();

        protected Spell(float damage)
        {
            _damage = damage;
            CreateVisitors();
        }


        public virtual void Cast(IVisitable caster, List<IVisitable> targets)
        {
            Console.Out.WriteLine($"\n=== {caster.GetType().Name} casts {GetType().Name} ===");
            foreach (var target in targets)
            {
                target.Accept(_mainEffectVisitor);
                if (_secondaryEffectVisitor != null)
                {
                    target.Accept(_secondaryEffectVisitor);
                }
            }
        }
    }
}