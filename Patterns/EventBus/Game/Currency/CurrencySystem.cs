using Patterns.EventBus.Events;

namespace Patterns.EventBus.Game.Currency
{
    public class CurrencySystem : IDisposable
    {
        private readonly Dictionary<CurrencyType, int> _currencies = new()
        {
            { CurrencyType.Coins, 0 },
            { CurrencyType.Gems, 0 }
        };

        public void AddCurrency(CurrencyType currencyType, int amount)
        {
            if (!_currencies.ContainsKey(currencyType)) return;
            _currencies[currencyType] += amount;
            
            EventBus.Invoke(new CurrencyValueChangedEvent(currencyType, _currencies[currencyType]));
        }

        public bool SpendCurrency(CurrencyType currencyType, int amount)
        {
            if (!_currencies.ContainsKey(currencyType)) return false;
            if (_currencies[currencyType] < amount) return false;
            _currencies[currencyType] -= amount;
            
            EventBus.Invoke(new CurrencyValueChangedEvent(currencyType, _currencies[currencyType]));
            return true;
        }

        public bool TryGetCurrency(CurrencyType currencyType, out int currency)
        {
            currency = 0;
            if (!_currencies.ContainsKey(currencyType)) return false;
            currency = _currencies[currencyType];
            return true;
        }

        public void Dispose()
        {
            
        }
    }

    public enum CurrencyType : byte
    {
        Coins = 0,
        Gems = 1,
    }
}