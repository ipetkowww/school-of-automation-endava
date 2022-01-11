using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    public class HomePage : BasePage
    {
        private static readonly By LoggedInInfo = By.CssSelector(".dropdown-toggle");
        private static readonly By ErrorMessage = By.CssSelector(".alert-danger");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetLoggedInfo()
        {
            WaitForElementToLoad(LoggedInInfo, Timeout10Seconds);
            return GetElementText(LoggedInInfo);
        }

        public bool IsErrorDisplayed()
        {
            WaitForElementToLoad(ErrorMessage, Timeout10Seconds);
            return FindElement(ErrorMessage).Displayed;
        }
    }
}