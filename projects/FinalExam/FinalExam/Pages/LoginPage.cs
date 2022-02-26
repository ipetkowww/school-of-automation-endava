using OpenQA.Selenium;

namespace FinalExam.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By LoginForm = By.CssSelector("#loginPanel");
        private static readonly By Username = By.CssSelector("input[name='username']");
        private static readonly By Password = By.CssSelector("input[name='password']");
        private static readonly By LoginButton = By.CssSelector("input[value='Log In']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            AccountServicesSection = new AccountServicesSection(driver);
        }
        
        public AccountServicesSection AccountServicesSection { get; }

        public bool IsDisplayed()
        {
            WaitForElementToLoad(LoginForm, Timeout10Seconds);
            return IsElementDisplayed(LoginForm);
        }

        public void FillUsername(string username)
        {
            FillTextInElement(Username, username);
        }
        
        public void FillPassword(string password)
        {
            FillTextInElement(Password, password);
        }
        
        public void ClickLoginButton()
        {
            Click(LoginButton);
        }
    }
}