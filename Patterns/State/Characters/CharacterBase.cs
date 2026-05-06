using Patterns.State.Abilities;
using Patterns.State.Abilities.Data;
using Patterns.State.Characters.Interfaces;
using Patterns.State.Classes;
using Patterns.State.Classes.Data;

namespace Patterns.State.Characters
{
    public class CharacterBase : IDamageable, IDisposable
    {
        public Action OnDie;
        public bool IsAlive => _health > 0;
        public float CurrentHealth => _health;
        public float MaxHealth => _maxHealth;
        
        private float _health;
        private float _mana;
        private float _maxHealth;
        private float _maxMana;
        private List<EffectType> _effects = new ();
        
        private ClassBase _class;
        private GlobalCooldownManager _globalCooldownManager;
        protected AbilityBase? _currentAbility;

        public CharacterBase(float health, float mana, ClassType @class, GlobalCooldownManager globalCooldownManager)
        {
            _health = health;
            _mana = mana;
            _maxHealth = _health;
            _maxMana = mana;
            _globalCooldownManager = globalCooldownManager;
            
            _class = CreateClassByType(@class);
        }

        public void TakeDamage(float damage)
        {
            if (!IsAlive) 
            {
                Console.Out.WriteLine("Target is already dead!");
                return;
            }
            
            _health = Math.Max(_health - damage, 0);
            
            if (!IsAlive)
            {
                _effects.Clear();
                OnDie?.Invoke();
            }
        }

        public void CastSpell(string name, CharacterBase? target)
        {
            AbilityBase? ability = _class.GetSpell(name);
            if (ability == null)
            {
                Console.Out.WriteLine($"Spell {name} is not present on the spellist of {_class.GetType().Name}!");
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

        public bool TryCancelSpell()
        {
            if (_currentAbility == null)
            {
                Console.Out.WriteLine($"Can't cancel ability on {GetType().Name}! There is nothing to be cancelled!");
                return false; 
            }

            ICancelable? cancellableAbility = _currentAbility as ICancelable;

            if (cancellableAbility == null)
            {
                Console.Out.WriteLine($"Ability {_currentAbility.GetType().Name} can not be cancelled!");
                return false;
            }

            cancellableAbility.Cancel();
            Console.Out.WriteLine($"{_currentAbility} was Cancelled!!!");
            _currentAbility = null;
            return true;
        }

        public bool TryInterruptSpell()
        {
            if (_currentAbility == null)
            {
                Console.Out.WriteLine($"Can't cancel ability on {GetType().Name}! There is nothing to be cancelled!");
                return false;
            }

            IInterruptable? interruptableAbility = _currentAbility as IInterruptable;
            if (interruptableAbility == null)
            {
                Console.Out.WriteLine($"Ability {_currentAbility.GetType().Name} can not be Interrupted!");
                return false;
            }
            
            interruptableAbility.Interrupt();
            Console.Out.WriteLine($"{_currentAbility} was Interrupted!!!");
            _currentAbility = null;
            return true;
        }

        public bool TryApplyEffect(EffectType effectType)
        {
            if (_effects.Contains(effectType)) return false;
            
            _effects.Add(effectType);
            Console.Out.WriteLine($"Effect {effectType} was added to the {this}");

            return true;
        }

        public bool TryRemoveEffect(EffectType effectType)
        {
            if (_effects.Contains(effectType))
            {
                _effects.Remove(effectType);
                Console.Out.WriteLine($"Effect {effectType} was removed from the the {this}");
                return true;
            }

            return false;
        }

        public bool IsEffectActive(EffectType effectType) => _effects.Any(i => i.Equals(effectType));

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