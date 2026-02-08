namespace Patterns.Memento.Validation
{
    public interface IValidationHandler
    {
        bool Handle();

        IValidationHandler SetNext(IValidationHandler handler);
    }
}