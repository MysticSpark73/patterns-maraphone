using Patterns.State.Characters.Interfaces;
using Patterns.State.Classes;

namespace Patterns.State.Characters
{
    public class CharacterBase : IDamageable
    {
        public bool IsAlive => _health > 0;
        
        private int _health;
        private int _mana;
        
        private ClassBase _class;
        private GlobalCooldownManager _globalCooldownManager;
        
        public void TakeDamage(int damage)
        {
            if (!IsAlive) 
            {
                Console.Out.WriteLine("Target is already dead!");
                return;
            }
            
            _health = Math.Max(_health - damage, 0);
        }
    }
}