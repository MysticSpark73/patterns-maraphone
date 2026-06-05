using Patterns.Visitor.Entities.Interfaces;
using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Entities
{
    public class Undead : Entity, IBurnable
    {
        public Undead(int health) : base(health)
        {
        }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
        
        public void ApplyBurn()
        {
            Console.Out.WriteLine($"{GetType().Name} is now burning!");
        }
    }
}