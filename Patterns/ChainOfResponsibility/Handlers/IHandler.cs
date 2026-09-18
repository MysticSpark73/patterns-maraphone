using Patterns.ChainOfResponsibility.Data;

namespace Patterns.ChainOfResponsibility.Handlers
{
    public interface IHandler
    {
        bool Handle(SaveData saveData);

        IHandler SetNext(IHandler handler);
    }
}