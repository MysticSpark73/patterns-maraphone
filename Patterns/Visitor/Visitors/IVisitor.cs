using Patterns.Visitor.Entities;

namespace Patterns.Visitor.Visitors
{
    public interface IVisitor
    {
        void Visit(Humanoid humanoid);
        void Visit(Undead undead);
        void Visit(Construct construct);
        void Visit(FireElemental fireElemental);
    }
}