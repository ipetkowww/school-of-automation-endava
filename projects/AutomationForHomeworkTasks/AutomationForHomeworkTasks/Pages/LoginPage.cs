using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By EmailField = By.CssSelector("input[type='email']");
        private static readonly By PasswordField = By.CssSelector("input[type='password']");
        private static readonly By LoginButton = By.CssSelector(".btn-primary");
        private static readonly By ErrorMessage = By.CssSelector(".alert-danger");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillEmailAddress(string email)
        {
            FillTextInElement(EmailField, email);
        }

        public void FillPassword(string password)
        {
            FillTextInElement(PasswordField, password);
        }

        public HomePage ClickLoginButton()
        {
            Click(LoginButton);
            return new HomePage(_driver);
        }

        public bool IsErrorMessageDisplayed()
        {
            WaitForElementToLoad(ErrorMessage, Timeout10Seconds);
            return FindElement(ErrorMessage).Displayed;
        }

        public string GetErrorMessageText()
        {
            WaitForElementToLoad(ErrorMessage, Timeout10Seconds);
            return GetElementText(ErrorMessage);
        }
    }
}