using Patterns.Common;

namespace Patterns.Singleton
{
    public class SingletonMain : IProgram
    {

        private Database _database;
        private Database _testDatabase;
    
        public void Run(object[]? args = null)
        {
            _database = Database.GetInstance();
            _database.AddCurrency(100);
            _testDatabase = Database.GetInstance();
            _testDatabase.SpendCurrency(50);
            _testDatabase.SpendCurrency(50);
        }
    }
}