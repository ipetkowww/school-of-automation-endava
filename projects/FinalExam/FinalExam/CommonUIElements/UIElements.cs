using OpenQA.Selenium;

namespace FinalExam.CommonUIElements
{
    public class UIElements
    {
        public static readonly By FirstName = By.Id("customer.firstName");
        public static readonly By LastName = By.Id("customer.lastName");
        public static readonly By Address = By.Id("customer.address.street");
        public static readonly By City = By.Id("customer.address.city");
        public static readonly By State = By.Id("customer.address.state");
        public static readonly By Zipcode = By.Id("customer.address.zipCode");
        public static readonly By SSN = By.Id("customer.ssn");
        public static readonly By Username = By.Id("customer.username");
        public static readonly By Password = By.Id("customer.password");
        public static readonly By Confirm = By.Id("repeatedPassword");
    }
}