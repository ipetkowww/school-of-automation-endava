using OpenQA.Selenium;

namespace ExamBasicAutomation.Pages
{
    public class RegistrationPage : BasePage
    {
        private static readonly By _firstNameField = By.CssSelector("#customer_firstname");
        private static readonly By _lastNameField = By.CssSelector("#customer_lastname");
        private static readonly By _passwordField = By.CssSelector("#passwd");
        private static readonly By _addressField = By.CssSelector("#address1");
        private static readonly By _cityField = By.CssSelector("#city");
        private static readonly By _stateField = By.CssSelector("#id_state");
        private static readonly By _postcodeField = By.CssSelector("#postcode");
        private static readonly By _mobilePhoneField = By.CssSelector("#phone_mobile");
        private static readonly By _aliasField = By.CssSelector("#alias");
        private static readonly By _registerButton = By.CssSelector("#submitAccount");
        private static readonly By _days = By.CssSelector("#days");
        private static readonly By _months = By.CssSelector("#months");
        private static readonly By _years = By.CssSelector("#years");

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void EnterFirstName(string firstName)
        {
            WaitForElementToLoad(_firstNameField, Timeout30Seconds);
            FillTextInElement(_firstNameField, firstName);
        }

        public void EnterLastName(string lastName)
        {
            FillTextInElement(_lastNameField, lastName);
        }

        public void EnterPassword(string password)
        {
            FillTextInElement(_passwordField, password);
        }

        public void EnterAddress(string address)
        {
            FillTextInElement(_addressField, address);
        }

        public void EnterCity(string city)
        {
            FillTextInElement(_cityField, city);
        }

        public void SelectState(string state)
        {
            GetSelectDropdownElement(_stateField).SelectByText(state);
        }

        public void EnterPostalCode(string postalCode)
        {
            FillTextInElement(_postcodeField, postalCode);
        }

        public void EnterMobilePhoneNumber(string phoneNumber)
        {
            FillTextInElement(_mobilePhoneField, phoneNumber);
        }

        public void EnterAddressAlias(string addressAlias)
        {
            FillTextInElement(_aliasField, addressAlias);
        }

        public MyAccountPage ClickRegisterButton()
        {
            Click(_registerButton);
            return new MyAccountPage(_driver);
        }
    }
}
