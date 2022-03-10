using AutoFramework.Pages;
using AutoFramework.Pages.Admin;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutoFramework.Steps.Admin
{
    [Binding]
    public class AdminLoginSteps
    {
        private readonly BasePage _basePage;
        private readonly LoginPage _loginPage;

        public AdminLoginSteps(IWebDriver driver)
        {
            _basePage = new BasePage(driver);
            _loginPage = new LoginPage(driver);
        }

        [Given(@"The user opens Admin Portal ""(.*)"" page")]
        public void GivenTheUserOpensAdminPortalPage(string pageName)
        {
            _basePage.OpenPage(pageName);
        }

        [When(@"The user logs in into the system with username ""(.*)"" and password ""(.*)""")]
        public void WhenTheUserLogsInIntoTheSystemWithUsernameAndPassword(string username, string password)
        {
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLoginButton();
        }
    }
}