using Patterns.EventBus.Events;
using Patterns.EventBus.Game.Currency;

namespace Patterns.EventBus.Game.UI
{
    public class UISystem : IDisposable
    {
        public UISystem()
        {
            EventBus.Subscribe<CurrencyValueChangedEvent>(OnCurrencyValueChanged);
            EventBus.Subscribe<ScoreValueChangedEvent>(OnScoreValueChanged);
        }

        private void OnCurrencyValueChanged(CurrencyValueChangedEvent eventData)
        {
            switch (eventData.CurrencyType)
            {
                case CurrencyType.Coins:
                    DisplayCoins(eventData.value);
                    break;
                case CurrencyType.Gems:
                    DisplayGems(eventData.value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnScoreValueChanged(ScoreValueChangedEvent eventData)
        {
            DisplayScore(eventData.score);
        }

        private void DisplayCoins(int amount)
        {
            Console.Out.WriteLine($"[UI] Coins: {amount}");
        }

        private void DisplayGems(int amount)
        {
            Console.Out.WriteLine($"[UI] Gems: {amount}");
        }

        private void DisplayScore(int score)
        {
            Console.Out.WriteLine($"[UI] Score : {score}");
        }

        public void Dispose()
        {
            EventBus.Unsubscribe<CurrencyValueChangedEvent>(OnCurrencyValueChanged);
            EventBus.Unsubscribe<ScoreValueChangedEvent>(OnScoreValueChanged);
        }
    }
}