using OpenQA.Selenium;

namespace FinalExam.Pages
{
    public class AccountServicesSection : BasePage
    {
        private static readonly By LogOutButton = By.CssSelector("a[href*='logout']");
        private static readonly By UpdateContactInfoLink = By.CssSelector("a[href*='updateprofile']");
        
        public AccountServicesSection(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLogOutButton()
        {
            Click(LogOutButton);
        }

        public bool IsLogoutButtonDisplayed()
        {
            WaitForElementToLoad(LogOutButton, Timeout10Seconds);
            return IsElementDisplayed(LogOutButton);
        }

        public void ClickUpdateContactInfo()
        {
            WaitForElementToLoad(UpdateContactInfoLink, Timeout10Seconds);
            Click(UpdateContactInfoLink);
        }
    }
}