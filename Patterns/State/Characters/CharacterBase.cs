using Patterns.State.Abilities;
using Patterns.State.Abilities.Data;
using Patterns.State.Characters.Interfaces;
using Patterns.State.Classes;
using Patterns.State.Classes.Data;

namespace Patterns.State.Characters
{
    public class CharacterBase : IDamageable, IDisposable
    {
        public bool IsAlive => _health > 0;
        
        private int _health;
        private int _mana;
        
        private ClassBase _class;
        private GlobalCooldownManager _globalCooldownManager;
        protected AbilityBase _currentAbility;

        public CharacterBase(int health, int mana, ClassType @class, GlobalCooldownManager globalCooldownManager)
        {
            _health = health;
            _mana = mana;
            _globalCooldownManager = globalCooldownManager;
            
            _class = CreateClassByType(@class);
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive) 
            {
                Console.Out.WriteLine("Target is already dead!");
                return;
            }
            
            _health = Math.Max(_health - damage, 0);
        }

        public void CastSpell(string name, CharacterBase? target)
        {
            AbilityBase? ability = _class.GetSpell(name);
            if (ability == null)
            {
                Console.Out.WriteLine($"Spell {name} is not present on the spellist of {_class.GetType()}!");
                return;
            }

            if (ability.RequestCast(new AbilityCastData()
                {
                    caster = this,
                    ability = ability,
                    target = target
                }))
            {
                _currentAbility = ability;
            }
        }

        public void CancelSpell()
        {
            //todo: Implement Cancel cuurent spell
        }

        public void InterruptSpell()
        {
            //todo: Implement Interrupt cuurentSpell
        }

        private ClassBase CreateClassByType(ClassType classType) => classType switch
        {
            ClassType.Warlock => new WarlockClass(_globalCooldownManager),
            _ => throw new ArgumentOutOfRangeException(nameof(classType), classType, null)
        };
        
        public void Dispose()
        {
            _globalCooldownManager.Dispose();
        }
    }
}