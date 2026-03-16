using Patterns.Common;
using Patterns.EventBus.Events;
using Patterns.EventBus.Game;
using Patterns.EventBus.Game.Achievements;
using Patterns.EventBus.Game.Currency;
using Patterns.EventBus.Game.Enemies;
using Patterns.EventBus.Game.Levels;
using Patterns.EventBus.Game.Score;
using Patterns.EventBus.Game.UI;

namespace Patterns.EventBus
{
    public class EventBusMain : IProgram, IDisposable
    {
        private CurrencySystem _currencySystem;
        private ScoreSystem _scoreSystem;
        private AchievementSystem _achievementSystem;
        private UISystem _uiSystem;
        private Level[] _levels;
        
        public void Run(object[]? args = null)
        {
            CreateSystems();
            SubscribeToGlobalEvents();
            CreateLevels();
            SimulateGameLoop();
            
            Dispose();
        }

        private void CreateSystems()
        {
            _currencySystem = new CurrencySystem();
            _scoreSystem = new ScoreSystem();
            _achievementSystem = new AchievementSystem();
            _uiSystem = new UISystem();
        }

        private void CreateLevels()
        {
            _levels = new[]
            {
                new Level(new Enemy[]
                {
                    new ("Green Slime", 10, 5),
                    new ("Green Slime", 10, 5),
                    new ("Green Slime", 10, 5),
                }),
                new Level(new Enemy[]
                {
                    new ("Green Slime", 10, 5),
                    new ("Green Slime", 10, 5),
                    new ("Blue Slime", 15, 5),
                    new ("Blue Slime", 15, 5),
                    new ("Blue Slime", 15, 5),
                }),
                new Level(new Enemy[]
                {
                    new ("Blue Slime", 15, 5),
                    new ("Blue Slime", 15, 5),
                    new ("Skeleton", 20, 10),
                    new ("Skeleton", 20, 10),
                }),
                new Level(new Enemy[]
                {
                    new ("Skeleton", 20, 10),
                    new ("Skeleton", 20, 10),
                    new ("Giant Centipede", 25, 5),
                    new ("Giant Centipede", 25, 5),
                    new ("Skeleton Warrior", 30, 15),
                    new ("Skeleton Warrior", 30, 15),
                }),
                new Level(new Enemy[]
                {
                    new ("Necromancer", 100, 150, 3)
                })
            };
        }

        private void SimulateGameLoop()
        {
            for (int i = 0; i < _levels.Length; i++)
            {
                _levels[i].Play();
            }
        }

        private void OnLevelComplete(LevelCompleteEvent eventData)
        {
            Console.Out.WriteLine($"Level {GameData.LevelIndex + 1} complete!");
            GrantLevelRewards(eventData._rewards);
            EventBus.Invoke(new LevelFinishedEvent(GameData.LevelIndex));
            GameData.LevelIndex++;
        }

        private void GrantLevelRewards(Dictionary<CurrencyType, int> levelRewards)
        {
            if (levelRewards.ContainsKey(CurrencyType.Coins))
            {
                levelRewards[CurrencyType.Coins] += GameData.CoinsForLevel;
            }
            else
            {
                levelRewards.Add(CurrencyType.Coins, GameData.CoinsForLevel);
            }
            
            if (levelRewards.TryGetValue(CurrencyType.Coins, out var coins))
            {
                _currencySystem.AddCurrency(CurrencyType.Coins, coins);
            }

            if (levelRewards.TryGetValue(CurrencyType.Gems, out var gems))
            {
                _currencySystem.AddCurrency(CurrencyType.Gems, gems);
            }
        }

        private void SubscribeToGlobalEvents()
        {
            EventBus.Subscribe<LevelCompleteEvent>(OnLevelComplete);
        }

        private void UnsubscribeFromGlobalEvents()
        {
            EventBus.Unsubscribe<LevelCompleteEvent>(OnLevelComplete);
        }

        public void Dispose()
        {
            UnsubscribeFromGlobalEvents();
            
            _currencySystem.Dispose();
            _scoreSystem.Dispose();
            _achievementSystem.Dispose();
            _uiSystem.Dispose();
        }
    }
}