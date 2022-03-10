using FinalExam.CommonUIElements;
using OpenQA.Selenium;

namespace FinalExam.Pages
{
    public class UpdateProfilePage : BasePage
    {
        private static readonly By UpdateProfileButton = By.CssSelector("input[type='submit']");
        private static readonly By SuccessfulMessageForUpdate = By.CssSelector("#rightPanel p");
        private static readonly By UpdateForm = By.CssSelector("div[ng-app='UpdateProfileApp']");
        
        public UpdateProfilePage(IWebDriver driver) : base(driver)
        {
            AccountServicesSection = new AccountServicesSection(driver);
        }

        public string FirstNameValue => GetTextFromValueAttribute(UIElements.LastName);
        public string LastNameValue => GetTextFromValueAttribute(UIElements.LastName);
        public string AddressValue => GetTextFromValueAttribute(UIElements.Address);
        public string CityValue => GetTextFromValueAttribute(UIElements.City);
        public string StateValue => GetTextFromValueAttribute(UIElements.State);
        public string ZipcodeValue => GetTextFromValueAttribute(UIElements.Zipcode);
        public AccountServicesSection AccountServicesSection { get; }

        public bool IsUpdateFormDisplayed()
        {
            WaitForElementToLoad(UpdateForm, 30);
            return IsElementDisplayed(UpdateForm);
        }
        
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

        public void ClickUpdateProfileButton()
        {
         Click(UpdateProfileButton);   
        }

        public string GetSuccessfulMessageForUpdate()
        {
            WaitForElementToLoad(SuccessfulMessageForUpdate, Timeout10Seconds);
            return GetElementText(SuccessfulMessageForUpdate);
        }
    }
}