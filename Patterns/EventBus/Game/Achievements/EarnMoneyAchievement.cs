using Patterns.EventBus.Events;
using Patterns.EventBus.Game.Currency;

namespace Patterns.EventBus.Game.Achievements
{
    public class EarnMoneyAchievement : AchievementBase
    {
        private const int TargetCoins = 500;
        private int _cachedCoins = 0;
        
        public EarnMoneyAchievement(string name) : base(name)
        {
            _condition = () => _cachedCoins >= TargetCoins;
            EventBus.Subscribe<CurrencyValueChangedEvent>(OnCurrencyChanged);
        }

        private void OnCurrencyChanged(CurrencyValueChangedEvent eventData)
        {
            if (eventData.CurrencyType != CurrencyType.Coins) return;

            _cachedCoins = eventData.value;
            TryUnlock();
        }

        public override void Dispose()
        {
            EventBus.Unsubscribe<CurrencyValueChangedEvent>(OnCurrencyChanged);
        }
    }
}