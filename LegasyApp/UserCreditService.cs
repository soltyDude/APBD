namespace LegacyApp
{
    public interface IUserCreditServiceFactory
    {
        IUserCreditService CreateUserCreditService(string clientType);
    }

    public interface IUserCreditService : IDisposable
    {
        int GetCreditLimit(string lastName, DateTime dateOfBirth);
    }

    public class UserCreditService : IUserCreditService
    {
        private readonly Dictionary<string, int> _database = new Dictionary<string, int>()
        {
            {"Kowalski", 200},
            {"Malewski", 20000},
            {"Smith", 10000},
            {"Doe", 3000},
            {"Kwiatkowski", 1000}
        };

        public int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            // Simulate contacting remote service to get credit limit
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);

            if (_database.ContainsKey(lastName))
                return _database[lastName];

            throw new ArgumentException($"Client {lastName} does not exist");
        }

        public void Dispose()
        {
            // Dispose resources
        }
    }

    public class UserCreditServiceFactory : IUserCreditServiceFactory
    {
        public IUserCreditService CreateUserCreditService(string clientType)
        {
            // Return appropriate UserCreditService based on client type
            if (clientType == "ImportantClient")
                return new UserCreditService();
            else
                return null; // Handle other cases accordingly
        }
    }
}