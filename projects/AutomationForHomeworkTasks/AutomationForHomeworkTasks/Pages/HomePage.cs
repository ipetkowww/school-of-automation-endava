using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    public class HomePage : BasePage
    {
        private static readonly By LoggedInInfo = By.CssSelector(".dropdown-toggle");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetLoggedInfo()
        {
            WaitForElementToLoad(LoggedInInfo, Timeout10Seconds);
            return GetElementText(LoggedInInfo);
        }
    }
}