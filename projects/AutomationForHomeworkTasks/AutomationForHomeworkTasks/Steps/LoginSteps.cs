using AutomationForHomeworkTasks.Pages;
using AutomationForHomeworkTasks.TestData;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static NUnit.Framework.Assert;

namespace AutomationForHomeworkTasks.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly UserTestData _userTestData;
        private readonly IWebDriver _driver;

        public LoginSteps(IWebDriver driver, UserTestData userTestData)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver);
            _userTestData = userTestData;
        }

        [When(@"The user logs in with email ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenTheUserLogsInWithEmailAndPassword(string email, string password)
        {
            _userTestData.Email = email;
            _userTestData.Password = password;

            _loginPage.FillEmailAddress(_userTestData.Email);
            _loginPage.FillPassword(_userTestData.Password);
            _loginPage.ClickLoginButton();
        }

        [Then(@"The 'Invalid user or email' error message is displayed")]
        public void ThenTheErrorMessageIsDisplayed()
        {
            IsTrue(_loginPage.IsErrorMessageDisplayed(), "Error message is not displayed");
        }
    }
}