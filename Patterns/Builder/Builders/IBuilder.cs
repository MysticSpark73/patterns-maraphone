namespace Patterns.Builder.Builders;

public interface IBuilder<T>
{
    public T Build();

    public IBuilder<T> Reset();
}