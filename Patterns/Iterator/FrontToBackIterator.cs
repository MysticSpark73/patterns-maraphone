using System.Collections;

namespace Patterns.Iterator
{
    public class FrontToBackIterator<T> : IEnumerable<T>
    {
        private List<T> _collection;

        public FrontToBackIterator(List<T> collection)
        {
            _collection = collection;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _collection.Count; i++)
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