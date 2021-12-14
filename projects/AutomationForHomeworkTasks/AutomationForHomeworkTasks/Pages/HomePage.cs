using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    public class HomePage : BasePage
    {
        private static readonly By loggedInInfo = By.CssSelector(".dropdown-toggle");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetLoggedInfo()
        {
            return GetElementText(loggedInInfo);
        }
    }
}
