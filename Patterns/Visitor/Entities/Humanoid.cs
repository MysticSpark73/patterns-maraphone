using Patterns.Visitor.Entities.Interfaces;
using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Entities
{
    public class Humanoid : Entity, IBurnable, IPoisonable
    {
        public Humanoid(int health) : base(health)
        {
        }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
        
        public void ApplyBurn()
        {
            Console.Out.WriteLine($"{GetType().Name} is now burning!");
        }

        public float ApplyPoison(float damage)
        {
            float damageTaken = TakeDamage(damage);
            Console.Out.WriteLine($"{GetType().Name} is now poisoned!");
            return damageTaken;
        }
    }
}