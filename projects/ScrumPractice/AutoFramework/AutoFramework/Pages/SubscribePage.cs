using OpenQA.Selenium;

namespace AutoFramework.Pages
{
    public class SubscribePage : BasePage
    {
        private static readonly By FirstName = By.CssSelector("#mat-input-0");
        private static readonly By LastName = By.CssSelector("#mat-input-1");
        private static readonly By Email = By.CssSelector("#mat-input-2");
        private static readonly By Phone = By.CssSelector("#mat-input-3");
        private static readonly By Major = By.CssSelector("#mat-input-4");
        private static readonly By GraduationStatus = By.CssSelector("#mat-select-0");
        private static readonly By PreferredTechnologies = By.CssSelector("[formarrayname='technologies']");
        private static readonly By SubscribeButton = By.CssSelector("[class*='mat-raised-button']");
        
        public SubscribePage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsFirstNameFieldDisplayed()
        {
            return IsElementDisplayed(FirstName);
        }

        public bool IsLastNameFieldDisplayed()
        {
            return IsElementDisplayed(LastName);
        }
        
        public bool IsEmailFieldDisplayed()
        {
            return IsElementDisplayed(Email);
        }

        public bool IsPhoneFieldDisplayed()
        {
            return IsElementDisplayed(Phone);
        }
        
        public bool IsMajorFieldDisplayed()
        {
            return IsElementDisplayed(Major);
        }

        public bool IsGraduationStatusDisplayed()
        {
            return IsElementDisplayed(GraduationStatus);
        }

        public bool IsPreferredTechnologiesDisplayed()
        {
            return IsElementDisplayed(PreferredTechnologies);
        }

        public bool IsSubscribeButtonDisplayed()
        {
            return IsElementDisplayed(SubscribeButton);
        }

        public bool IsSubscribeButtonEnabled()
        {
            return FindElement(SubscribeButton).Enabled;
        }
    }
}