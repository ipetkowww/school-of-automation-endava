using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FillTextInElement(By locator, string text)
        {
            FindElement(locator).Clear();
            FindElement(locator).SendKeys(text);
        }

        public IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public void Click(By locator)
        {
            FindElement(locator).Click();
        }

        public string GetElementText(By locator)
        {
            return FindElement(locator).Text;
        }
    }
}
