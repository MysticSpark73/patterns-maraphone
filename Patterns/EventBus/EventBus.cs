using Patterns.EventBus.Events;

namespace Patterns.EventBus
{
    public static class EventBus
    {

        private static readonly Dictionary<Type, List<Delegate>> _subscribers = new();

        public static void Subscribe<T>(Action<T> callback) where T : IEvent
        {
            if (!_subscribers.TryGetValue(typeof(T), out var delegates))
            {
                delegates = new List<Delegate>();
                _subscribers[typeof(T)] = delegates;
            }
            
            delegates.Add(callback);
        }
        
        public static void Unsubscribe<T>(Action<T> callback) where T : IEvent
        {
            if (!_subscribers.TryGetValue(typeof(T), out var delegates)) return;

            delegates.Remove(callback);

            if (delegates.Count == 0) _subscribers.Remove(typeof(T));
        }
        
        public static void Invoke<T>(T @event) where T : IEvent
        {
            if (!_subscribers.TryGetValue(typeof(T), out var delegates)) return;

            var listeners = delegates.ToArray();

            for (var i = 0; i < listeners.Length; i++)
            {
                var listener = listeners[i];
                ((Action<T>) listener).Invoke(@event);
            }
        }

        public static void Invoke<T>() where T : IEvent, new()
        {
            Invoke( new T());
        }
    }
}