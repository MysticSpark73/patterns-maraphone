using Patterns.EventBus.Events;
using Patterns.EventBus.Game.Currency;
using Patterns.EventBus.Game.Enemies;

namespace Patterns.EventBus.Game.Levels
{
    public class Level(Enemy[] enemies)
    {
        private Dictionary<CurrencyType, int> _levelRewards = new ();

        private void AddEnemyRewards(Enemy enemy)
        {
            var rewards = enemy.Rewards;
            if (rewards.TryGetValue(CurrencyType.Coins, out var coins))
            {
                if (_levelRewards.ContainsKey(CurrencyType.Coins))
                {
                    _levelRewards[CurrencyType.Coins] += coins;
                }
                else
                {
                    _levelRewards.Add(CurrencyType.Coins, coins);
                }
            }

            if (rewards.TryGetValue(CurrencyType.Gems, out var gems))
            {
                if (_levelRewards.ContainsKey(CurrencyType.Gems))
                {
                    _levelRewards[CurrencyType.Gems] += gems;
                }
                else
                {
                    _levelRewards.Add(CurrencyType.Gems, gems);
                }
            }
        }

        public void Play()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Kill();
                AddEnemyRewards(enemies[i]);
            }
            EventBus.Invoke(new LevelCompleteEvent(new Dictionary<CurrencyType, int>(_levelRewards)));
        }
    }
}