using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;

namespace ExamBasicAutomation.Pages
{
    public class BasePage
    {
        protected static readonly int Timeout30Seconds = 30;
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

        protected ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return _driver.FindElements(locator);
        }

        protected bool IsElementDisplayed(By locator)
        {
            return FindElement(locator).Displayed;
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

        protected void WaitForElementToBeClickable(By locator, int timeoutInSeconds)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected void WaitForElementToDissapear(By locator, int timeoutInSeconds)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        protected SelectElement GetSelectDropdownElement(By selector)
        {
            return new SelectElement(FindElement(selector));
        }
    }
}