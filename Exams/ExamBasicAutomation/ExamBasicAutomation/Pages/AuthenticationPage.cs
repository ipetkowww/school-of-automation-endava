using ExamBasicAutomation.Pages;
using OpenQA.Selenium;

namespace ExamBaiscAutomation.Pages
{
    public class AuthenticationPage : BasePage
    {
        private static readonly By _emailField = By.CssSelector("#email_create");
        private static readonly By _createAccountButton = By.CssSelector("#SubmitCreate");

        public AuthenticationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void EnterEmailInEmailField(string email)
        {
            WaitForElementToLoad(_emailField, Timeout30Seconds);
            FillTextInElement(_emailField, email);
        }

        public RegistrationPage ClickCreateAccountButton()
        {
            Click(_createAccountButton);
            return new RegistrationPage(_driver);
        }
    }
}
