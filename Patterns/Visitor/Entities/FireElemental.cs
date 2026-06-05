using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Entities
{
    public class FireElemental : Entity
    {
        public FireElemental(int health) : base(health)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}