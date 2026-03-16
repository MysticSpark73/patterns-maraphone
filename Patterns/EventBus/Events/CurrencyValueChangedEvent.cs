using Patterns.EventBus.Game.Currency;

namespace Patterns.EventBus.Events
{
    public struct CurrencyValueChangedEvent(CurrencyType currencyType, int value) : IEvent
    {
        public CurrencyType CurrencyType = currencyType;
        public int value = value;
    }
}