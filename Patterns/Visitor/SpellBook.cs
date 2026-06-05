using Patterns.Visitor.Entities.Interfaces;
using Patterns.Visitor.Spells;

namespace Patterns.Visitor
{
    public class SpellBook
    {
        private readonly Dictionary<SpellType, Spell> _spells = new()
        {
            { SpellType.ShieldSlam, new ShieldSlam(30) },
            { SpellType.Fireball, new Fireball(150) },
            { SpellType.PoisonCloud, new PoisonCloud(70) },
            { SpellType.VampiricTouch, new VampiricTouch(60) },
            { SpellType.IceLance, new IceLance(80) },
            { SpellType.CullLightning, new CullLightning(125) }
        };

        public void Cast(SpellType spellType, IVisitable caster, List<IVisitable> targets)
        {
            if (_spells.TryGetValue(spellType, out var spell))
            {
                spell.Cast(caster, targets);
            }
            else
            {
                Console.Out.WriteLine($"There is no Spell with type {spellType}!");
            }
        }
    }
}