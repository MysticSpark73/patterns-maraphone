using Patterns.EventBus.Events;
using Patterns.EventBus.Game.Currency;

namespace Patterns.EventBus.Game.Enemies
{
    public class Enemy
    {
        public Dictionary<CurrencyType, int> Rewards => _rewards;
        private string _name;
        private int _score;
        private Dictionary<CurrencyType, int> _rewards;

        public Enemy(string name, int score, int coins, int? gems = null)
        {
            _name = name;
            _score = score;
            _rewards = new Dictionary<CurrencyType, int>();
            _rewards.Add(CurrencyType.Coins, coins);
            if (gems != null)
            {
                _rewards.Add(CurrencyType.Gems, gems.Value);
            }
        }

        public void Kill()
        {
            Console.Out.WriteLine($"{_name} was slain!");
            EventBus.Invoke(new EnemyKilledEvent(_score));
        }
    }
}