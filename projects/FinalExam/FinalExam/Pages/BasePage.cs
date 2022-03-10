using System;
using FinalExam.Configuration;
using FinalExam.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalExam.Pages
{
    public class BasePage
    {
        protected const int Timeout10Seconds = 10;
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
            new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(
                ExpectedConditions.ElementExists(locator));
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
            return FindElement(locator).Displayed;
        }

        protected string GetTextFromValueAttribute(By locator)
        {
            return FindElement(locator).GetAttribute("value");
        }
    }
}