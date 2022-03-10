using FinalExam.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FinalExam.Steps.UI
{
    [Binding]
    public class AccountServicesSteps
    {
        private readonly AccountServicesSection _accountServicesSection;

        public AccountServicesSteps(IWebDriver driver)
        {
            _accountServicesSection = new AccountServicesSection(driver);
        }


        [When(@"The user clicks on Update Contact Info link from Account Services")]
        public void WhenTheUserClicksOnUpdateContactInfoLinkFromAccountServices()
        {
            _accountServicesSection.ClickUpdateContactInfo();
        }
    }
}