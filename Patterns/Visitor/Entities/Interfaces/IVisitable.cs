using Patterns.Visitor.Visitors;

namespace Patterns.Visitor.Entities.Interfaces
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}