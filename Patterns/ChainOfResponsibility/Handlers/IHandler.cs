namespace Patterns.ChainOfResponsibility.Handlers
{
    public interface IHandler
    {
        bool Handle();

        IHandler SetNext(IHandler handler);
    }
}