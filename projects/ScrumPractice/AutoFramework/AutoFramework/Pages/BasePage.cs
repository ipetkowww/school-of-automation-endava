using System;
using System.Collections.ObjectModel;
using AutoFramework.Configuration;
using AutoFramework.Constants;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoFramework.Pages
{
    public class BasePage
    {
        protected const int Timeout10Seconds = 10;
        private const int Timeout1Second = 1;
        private readonly IWebDriver _driver;

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
    
        protected void Click(By locator)
        {
            FindElement(locator).Click();
        }
    
        protected string GetElementText(By locator)
        {
            return FindElement(locator).Text;
        }
    
        protected bool WaitForElementToLoad(By locator, int timeoutInSeconds)
        {
            var result = true;
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(
                    ExpectedConditions.ElementExists(locator));
            }
            catch (WebDriverTimeoutException)
            {
                result = false;
            }

            return result;
        }

        public void OpenPage(string pageName)
        {
            var baseUrl = ConfigurationProvider.GetConfigurationValue[AppConstants.BaseUrl];
            var page = ConfigurationProvider.GetConfigurationValue[$"{AppConstants.Pages}:{pageName.ToLower()}"];
            var url = $"{baseUrl}{page}";
            _driver.Navigate().GoToUrl(url);
        }

        protected bool IsElementDisplayed(By locator)
        {
            WaitForElementToLoad(locator, Timeout10Seconds);
            try
            {
                return FindElement(locator).Displayed;
            }
            catch
            {
                return false;
            }
        }

        protected void VerifyWebElementIsVisible(By elementLocator, string failMessage)
        {
            var isElementLoaded = WaitForElementToLoad(elementLocator, Timeout1Second);
            Assert.IsTrue(isElementLoaded, failMessage);
        }
    }
}