using Patterns.Common;
using Patterns.Visitor.Entities;
using Patterns.Visitor.Entities.Interfaces;
using Patterns.Visitor.Spells;

namespace Patterns.Visitor
{
    public class VisitorMain : IProgram
    {
        private SpellBook _spellBook;
        
        private Humanoid _wizard;
        private Humanoid _gladiator;
        private Undead _zombie;
        private Undead _skeleton;
        private Construct _steelSentinel;
        private FireElemental _fireElemental;
        
        public void Run(params object[]? args)
        {
            ScribeSpellBook();
            CreateEntities();
            CastSpells();
        }

        private void ScribeSpellBook()
        {
            _spellBook = new SpellBook();
        }

        private void CreateEntities()
        {
            _wizard = new Humanoid(1500);
            _gladiator = new Humanoid(800);
            _zombie = new Undead(500);
            _skeleton = new Undead(450);
            _steelSentinel = new Construct(1000);
            _fireElemental = new FireElemental(750);
        }

        private void CastSpells()
        {
            _spellBook.Cast(SpellType.ShieldSlam, _gladiator, new List<IVisitable>()
            {
                _wizard, _zombie, _skeleton, _steelSentinel, _fireElemental
            });

            _spellBook.Cast(SpellType.PoisonCloud, _zombie, new List<IVisitable>()
            {
                _wizard, _gladiator, _skeleton, _steelSentinel, _fireElemental
            });

            _spellBook.Cast(SpellType.Fireball, _wizard, new List<IVisitable>()
            {
                _wizard, _gladiator, _zombie, _skeleton, _steelSentinel, _fireElemental
            });

            _spellBook.Cast(SpellType.IceLance, _wizard, new List<IVisitable>()
            {
                _gladiator, _zombie, _skeleton, _steelSentinel, _fireElemental
            });

            _spellBook.Cast(SpellType.VampiricTouch, _zombie, new List<IVisitable>()
            {
                _wizard, _gladiator, _skeleton, _steelSentinel, _fireElemental
            });

            _spellBook.Cast(SpellType.CullLightning, _wizard, new List<IVisitable>()
            {
                _gladiator, _zombie, _skeleton, _steelSentinel, _fireElemental
            });
        }
    }
}