using AutoFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutoFramework.Steps
{
    [Binding]
    public class SubscribeSteps
    {
        private readonly SubscribePage _subscribePage;
        
        public SubscribeSteps(IWebDriver driver)
        {
            _subscribePage = new SubscribePage(driver);
        }
        
        
        [Then(@"First Name field is displayed")]
        public void ThenFirstNameFieldIsDisplayed()
        {
            Assert.IsTrue(_subscribePage.IsFirstNameFieldDisplayed(), "First Name field is not displayed");
        }

        [Then(@"Last Lame field is displayed")]
        public void ThenLastLameFieldIsDisplayed()
        {
            Assert.IsTrue(_subscribePage.IsLastNameFieldDisplayed(), "Last Name field is not displayed");
        }

        [Then(@"Email field is displayed")]
        public void ThenEmailFieldIsDisplayed()
        {
            Assert.IsTrue(_subscribePage.IsEmailFieldDisplayed(), "Email field is not displayed");
        }

        [Then(@"Phone number field is displayed")]
        public void ThenPhoneNumberFieldIsDisplayed()
        {
            Assert.IsTrue(_subscribePage.IsPhoneFieldDisplayed(), "Phone number field is not displayed");
        }

        [Then(@"Major field is displayed")]
        public void ThenMajorFieldIsDisplayed()
        {
            Assert.IsTrue(_subscribePage.IsMajorFieldDisplayed(), "Major field is not displayed");
        }

        [Then(@"Graduation status dropdown is displayed")]
        public void ThenGraduationStatusDropdownIsDisplayed()
        {
            Assert.IsTrue(_subscribePage.IsGraduationStatusDisplayed(), "Graduation field is not displayed");
        }

        [Then(@"Preferred Technologies field is displayed")]
        public void ThenPreferredTechnologiesFieldIsDisplayed()
        {
            Assert.IsTrue(_subscribePage.IsPreferredTechnologiesDisplayed(), 
                "Preferred Technologies field is not displayed");
        }

        [Then(@"Subscribe button is displayed")]
        public void ThenSubscribeButtonIsDisplayed()
        {
            Assert.IsTrue(_subscribePage.IsSubscribeButtonDisplayed(), "Subscribe button is not displayed");
        }

        [Then(@"Subscribe button is ""(.*)""")]
        public void ThenSubscribeButtonIs(string buttonState)
        {
            var isEnabled = _subscribePage.IsSubscribeButtonEnabled();
            switch (buttonState)
            {
                case "disabled":
                    Assert.IsFalse(isEnabled, "Subscribe button is enabled.");
                    break;
                case "enabled":
                    Assert.IsTrue(isEnabled, "Subscribe button is disabled");
                    break;
            }
        }
    }
}