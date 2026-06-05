using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Entities
{
    public class Construct : Entity
    {
        public Construct(int health) : base(health)
        {
        }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}