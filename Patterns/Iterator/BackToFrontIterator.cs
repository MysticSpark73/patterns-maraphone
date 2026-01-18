using System.Collections;

namespace Patterns.Iterator
{
    public class BackToFrontIterator<T> : IEnumerable<T>
    {
        private List<T> _collection;

        public BackToFrontIterator(List<T> collection)
        {
            _collection = collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _collection.Count - 1; i >= 0; i--)
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