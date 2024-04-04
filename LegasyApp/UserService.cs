using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditServiceFactory _userCreditServiceFactory;

        public UserService(IClientRepository clientRepository, IUserCreditServiceFactory userCreditServiceFactory)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _userCreditServiceFactory = userCreditServiceFactory ?? throw new ArgumentNullException(nameof(userCreditServiceFactory));
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || !IsValidEmail(email))
                return false;

            int age = CalculateAge(dateOfBirth);
            if (age < 21)
                return false;

            var client = _clientRepository.GetById(clientId);
            if (client == null)
                return false;

            var userCreditService = _userCreditServiceFactory.CreateUserCreditService(client.Type);
            if (userCreditService == null)
                return false;

            int creditLimit = userCreditService.GetCreditLimit(lastName, dateOfBirth);
            if (client.Type != "VeryImportantClient")
                creditLimit *= 2;

            if (creditLimit < 500 && client.Type != "VeryImportantClient")
                return false;

            var user = CreateUser(firstName, lastName, email, dateOfBirth, client, creditLimit);
            UserDataAccess.AddUser(user);
            return true;
        }

        private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client, int creditLimit)
        {
            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email,
                DateOfBirth = dateOfBirth,
                Client = client,
                CreditLimit = creditLimit,
                HasCreditLimit = client.Type != "VeryImportantClient"
            };
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
        
        private int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
                age--;
            return age;
        }
    }
}
