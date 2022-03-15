using AutoFramework.Configuration;
using AutoFramework.Constants;
using AutoFramework.Pages;
using AutoFramework.Pages.Admin;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutoFramework.Steps.Admin
{
    [Binding]
    public class GeneralSteps
    {
        private readonly AdminLoginSteps _adminLoginSteps;
        private readonly IntershipAdministrationPage _intershipAdministrationPage;
        private readonly BasePage _basePage;

        public GeneralSteps(IWebDriver driver)
        {
            _adminLoginSteps = new AdminLoginSteps(driver);
            _intershipAdministrationPage = new IntershipAdministrationPage(driver);
            _basePage = new BasePage(driver);
        }

        [Given(@"The admin is logged in in Admin Portal")]
        public void GivenTheAdminIsLoggedInInAdminPortal()
        {
            _adminLoginSteps.GivenTheUserOpensAdminPortalPage(PageNameConstants.LoginPage);
            var adminEmail =
                ConfigurationProvider.GetConfigurationValue[$"{AppConstants.Credentials}:{AppConstants.AdminEmail}"];
            var adminPassword = 
                ConfigurationProvider.GetConfigurationValue[$"{AppConstants.Credentials}:{AppConstants.AdminPassword}"];
                
                
                
            _adminLoginSteps.WhenTheUserLogsInIntoTheSystemWithUsernameAndPassword(adminEmail, adminPassword);
        }

        [When(@"The admin clicks on Add button for ""(.*)"" field")]
        public void WhenTheAdminClicksOnAddButtonForField(string fieldName)
        {
            _intershipAdministrationPage.ClickAddButtonFor(fieldName);
        }

        [Given(@"The user opens ""(.*)"" page")]
        public void GivenTheUserOpensPage(string pageName)
        {
            _basePage.OpenPage(pageName);
        }
    }
}