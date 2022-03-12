using AutoFramework.Constants;
using AutoFramework.Pages;
using AutoFramework.Pages.Admin;
using AutoFramework.TestData;
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
            _adminLoginSteps.WhenTheUserLogsInIntoTheSystemWithUsernameAndPassword(AdminUser.Email, AdminUser.Password);
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