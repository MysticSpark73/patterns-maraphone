using Patterns.Builder.Builders;

namespace Patterns.Builder.Directors
{
    public interface IDirector<T>
    {
        public void SetBuilder(IBuilder<T> builder);
    }
}