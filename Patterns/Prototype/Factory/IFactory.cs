namespace Patterns.Prototype.Factory;

public interface IFactory<T>
{
    public abstract T Create();
}