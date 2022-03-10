using OpenQA.Selenium;

namespace AutoFramework.Pages.Admin
{
    public class LoginPage : BasePage
    {
        private static readonly By Username = By.CssSelector("#id_username");
        private static readonly By Password = By.CssSelector("#id_password");
        private static readonly By LogInButton = By.CssSelector("input[type='submit']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterUsername(string username)
        {
            WaitForElementToLoad(Username, Timeout10Seconds);
            FillTextInElement(Username, username);
        }

        public void EnterPassword(string password)
        {
            FillTextInElement(Password, password);
        }

        public void ClickLoginButton()
        {
            Click(LogInButton);
        }
    }
}