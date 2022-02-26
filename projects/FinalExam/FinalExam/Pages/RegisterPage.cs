using FinalExam.CommonUIElements;
using OpenQA.Selenium;

namespace FinalExam.Pages
{
    public class RegisterPage : BasePage
    {
        private static readonly By RegisterButton = By.CssSelector("input[value='Register']");
        private static readonly By WelcomeTitle = By.CssSelector("h1");
        private static readonly By SuccessfulRegisterMessage = By.CssSelector("#rightPanel p");

        public RegisterPage(IWebDriver driver) : base(driver)
        {
            AccountServicesSection = new AccountServicesSection(driver);
        }
        
        public AccountServicesSection AccountServicesSection { get; set; }
    
        public void EnterFirstName(string firstName)
        {
            WaitForElementToLoad(UIElements.FirstName, Timeout10Seconds);
            FillTextInElement(UIElements.FirstName, firstName);
        }
    
        public void EnterLastName(string lastName)
        {
            FillTextInElement(UIElements.LastName, lastName);
        }

        public void EnterAddress(string address)
        {
            FillTextInElement(UIElements.Address, address);
        }
        
        public void EnterCity(string city)
        {
            FillTextInElement(UIElements.City, city);
        }
        
        public void EnterState(string state)
        {
            FillTextInElement(UIElements.State, state);
        }
        
        public void EnterZipcode(string zipcode)
        {
            FillTextInElement(UIElements.Zipcode, zipcode);
        }
        
        public void EnterSSN(string ssn)
        {
            FillTextInElement(UIElements.SSN, ssn);
        }
        
        public void EnterUsername(string username)
        {
            FillTextInElement(UIElements.Username, username);
        }
        
        public void EnterPassword(string password)
        {
            FillTextInElement(UIElements.Password, password);
        }
        
        public void EnterConfirmPassword(string confirmPassword)
        {
            FillTextInElement(UIElements.Confirm, confirmPassword);
        }
        
        public void ClickRegisterButton()
        {
            Click(RegisterButton);
        }

        public string GetWelcomeTitle()
        {
            WaitForElementToLoad(WelcomeTitle, Timeout10Seconds);
            return GetElementText(WelcomeTitle);
        }

        public string GetSuccessfulRegistrationMessage()
        {
            return GetElementText(SuccessfulRegisterMessage);
        }
    }
}