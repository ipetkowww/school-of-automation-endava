using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationForHomeworkTasks.Pages
{
    public class BasePage
    {
        protected static readonly int Timeout10Seconds = 10;
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected void FillTextInElement(By locator, string text)
        {
            FindElement(locator).Clear();
            FindElement(locator).SendKeys(text);
        }

        protected IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        protected void Click(By locator)
        {
            FindElement(locator).Click();
        }

        protected string GetElementText(By locator)
        {
            return FindElement(locator).Text;
        }

        protected void WaitForElementToLoad(By locator, int timeoutInSeconds)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
