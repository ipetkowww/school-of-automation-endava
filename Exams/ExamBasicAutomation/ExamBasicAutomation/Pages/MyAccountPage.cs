using ExamBasicAutomation.Constants;
using OpenQA.Selenium;

namespace ExamBasicAutomation.Pages
{
    public class MyAccountPage : BasePage
    {
        private static readonly By _firstAndLastName = By.CssSelector(".account");
        private static readonly By _pageHeading = By.CssSelector(".page-heading");

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public string GetPageHeadingText()
        {
            return GetElementText(_pageHeading);
        }

        public string GetFirstAndLastName()
        {
            return GetElementText(_firstAndLastName);
        }

        public bool IsDisplayed()
        {
            WaitForElementToLoad(_pageHeading, Timeout30Seconds);
            string v = GetElementText(_pageHeading);
            System.Console.WriteLine(v);
            return GetElementText(_pageHeading).Equals(AppConstants.MyAccountPageHeading);
        }
    }
}