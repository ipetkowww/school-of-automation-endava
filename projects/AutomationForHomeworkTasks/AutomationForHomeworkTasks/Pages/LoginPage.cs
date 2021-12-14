using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By _emailField = By.CssSelector("input[type='email']");
        private static readonly By _passwordField = By.CssSelector("input[type='password']");
        private static readonly By _loginButton = By.CssSelector(".btn-primary");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillEmailAddress(string email)
        {
            FillTextInElement(_emailField, email);
        }

        public void FillPassword(string password)
        {
            FillTextInElement(_passwordField, password);
        }

        public HomePage ClickLoginButton()
        {
            Click(_loginButton);
            return new HomePage(_driver);
        }
    }
}
