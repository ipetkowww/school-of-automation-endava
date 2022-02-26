using FinalExam.Pages;
using FinalExam.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FinalExam.Steps.UI
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly UserTestData _userTestData;

        public LoginSteps(IWebDriver driver, UserTestData userTestData)
        {
            _loginPage = new LoginPage(driver);
            _userTestData = userTestData;
        }

        [Given(@"Login page is displayed")]
        public void GivenLoginPageIsDisplayed()
        {
            Assert.IsTrue(_loginPage.IsDisplayed(), "Login Page is not displayed");
        }

        [When(@"The user logs in with username ""(.*)"" and password ""(.*)""")]
        public void WhenTheUserLogsInWithUsernameAndPassword(string username, string password)
        {
            username = _userTestData.Username!;
            _loginPage.FillUsername(username);
            _loginPage.FillPassword(password);
            _loginPage.ClickLoginButton();
        }

        [Then(@"The user is logged in successfully")]
        public void ThenTheUserIsLoggedInSuccessfully()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(_loginPage.AccountServicesSection.IsLogoutButtonDisplayed(), 
                    "Log Out button is not displayed.");
                
            });
        }
    }
}