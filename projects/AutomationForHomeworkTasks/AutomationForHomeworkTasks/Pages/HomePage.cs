using AutomationForHomeworkTasks.UIElements;
using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetLoggedInfo()
        {
            WaitForElementToLoad(HomePageUIElements.LoggedInInfo, Timeout10Seconds);
            return GetElementText(HomePageUIElements.LoggedInInfo);
        }

        public bool IsErrorDisplayed()
        {
            WaitForElementToLoad(HomePageUIElements.ErrorMessage, Timeout10Seconds);
            return FindElement(HomePageUIElements.ErrorMessage).Displayed;
        }

        public string GetUserTitleAndName()
        {
            WaitForElementToLoad(HomePageUIElements.UserTitleAndName, Timeout10Seconds);
            return GetElementText(HomePageUIElements.UserTitleAndName).Split(", ")[1];
        }
    }
}