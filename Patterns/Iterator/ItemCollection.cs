using System.Collections;

namespace Patterns.Iterator
{
    public class ItemCollection<T> : IEnumerable<T>
    {
        private List<T> _collection = new ();

        public void Add(T item) => _collection.Add(item);

        public int Count => _collection.Count;

        public IEnumerable<T> GetFrontToBackIterator() => new FrontToBackIterator<T>(_collection);

        public IEnumerable<T> GetBackToFrontIterator() => new BackToFrontIterator<T>(_collection);

        public IEnumerable<T> GetFromToStepIterator(int from, int to, int step) =>
            new FromToStepIterator<T>(_collection, from, to, step);
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