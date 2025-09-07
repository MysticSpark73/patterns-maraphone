using System;

namespace Patterns.Singleton
{
    public sealed class Database
    {
        private static Database _instance;

        private static readonly object _lock = new object();

        private int _currency;

        private Database()
        {
        
        }

        public static Database GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Database();
                    }
                }
            }

            return _instance;
        }

        public void AddCurrency(int value)
        {
            _currency += value;
            Console.WriteLine($"Currency added. Remaining currency {_currency}");
        }

        public void SpendCurrency(int value)
        {
            if (_currency < value)
            {
                Console.WriteLine("Not enough currency!!!");
                return;
            }

            _currency -= value;
            Console.WriteLine($"Currency spent successfully. Remaining currency: {_currency}");
        }
    }
}