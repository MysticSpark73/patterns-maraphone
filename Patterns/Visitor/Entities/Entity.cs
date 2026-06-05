using Patterns.Visitor.Entities.Interfaces;
using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Entities
{
    public abstract class Entity : IDamageable, IHealable, IVisitable, IStunable
    {
        protected float _health;
        protected float _maxHealth;

        protected Entity(int health)
        {
            _health = health;
            _maxHealth = health;
        }

        public virtual float TakeDamage(float damage)
        {
            float damageTaken = MathF.Max(MathF.Min(_health, damage), 0);
            _health -= damageTaken;
            Console.Out.WriteLine($"{GetType().Name} took {damageTaken} damage!");
            return damageTaken;
        }

        public virtual float Heal(float healValue)
        {
            float healthRestored = MathF.Max(MathF.Min(_maxHealth - _health, healValue), 0);
            _health += healthRestored;
            Console.Out.WriteLine($"{GetType().Name} was healed for {healthRestored}!");
            return healthRestored;
        }

        public void ApplyStun()
        {
            Console.Out.WriteLine($"{GetType().Name} is now stunned!");
        }

        public abstract void Accept(IVisitor visitor);

        //Alternative implementation for C# 4.0+

        //Although it is very convenient way of implementing Visitor it comes with a risk of run-time exceptions 

        /*public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit((dynamic) this);
        }*/
    }
}