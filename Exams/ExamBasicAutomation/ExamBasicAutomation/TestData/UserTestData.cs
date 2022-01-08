using System;

namespace ExamBasicAutomation.TestData
{
    public class UserTestData
    {
        private static readonly Random getRandom = new Random();

        public static readonly string RegistrationEmail = $"AutoEmail{GetRandomNUmber(1, 99999999)}@bqgai.com";

        public const string FirstName = "AutoFirst";
        public const string LastName = "AutoLast";
        public const string Password = "AutoPass";
        public const string Address = "AutoAddress";
        public const string City = "AutoCity";
        public const string AlabamaState = "Alabama";
        public const string PostalCode = "12345";
        public const string MobilePhoneNumber = "2519682467";
        public const string AddressAlias = "AutoAddressAlias";

        public const string BlouseProduct = "Blouse";

        private static int GetRandomNUmber(int min, int max)
        {
            return getRandom.Next(min, max);
        }
    }
}