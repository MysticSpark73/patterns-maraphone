using System.Collections;

namespace Patterns.Iterator
{
    public class FromToStepIterator<T> : IEnumerable<T>
    {
        private List<T> _collection;
        private int _from, _to, _step;

        public FromToStepIterator(List<T> collection, int from, int to, int step)
        {
            _collection = collection;
            _from = Math.Max(from, 0);
            _to = Math.Min(to, _collection.Count - 1);
            _step = Math.Min(step, _collection.Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _from; i < _to; i += _step)
            {
                yield return _collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}