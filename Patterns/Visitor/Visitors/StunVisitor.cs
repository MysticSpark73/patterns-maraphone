using Patterns.Visitor.Entities;

namespace Patterns.Visitor.Visitors
{
    public class StunVisitor : IVisitor
    {
        public void Visit(Humanoid humanoid)
        {
            humanoid.ApplyStun();
        }

        public void Visit(Undead undead)
        {
            undead.ApplyStun();
        }

        public void Visit(Construct construct)
        {
            construct.ApplyStun();
        }

        public void Visit(FireElemental fireElemental)
        {
            fireElemental.ApplyStun();
        }
    }
}