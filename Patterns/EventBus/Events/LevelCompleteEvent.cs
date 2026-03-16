using Patterns.EventBus.Game.Currency;

namespace Patterns.EventBus.Events
{
    public class LevelCompleteEvent(Dictionary<CurrencyType, int> rewards) : IEvent
    {
        public Dictionary<CurrencyType, int> _rewards = rewards;
    }
}