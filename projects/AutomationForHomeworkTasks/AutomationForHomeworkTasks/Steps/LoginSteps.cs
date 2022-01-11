using AutomationForHomeworkTasks.Pages;
using AutomationForHomeworkTasks.Steps.Hooks;
using AutomationForHomeworkTasks.TestData;
using static NUnit.Framework.Assert;
using TechTalk.SpecFlow;

namespace AutomationForHomeworkTasks.Steps
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage _loginPage;
        private readonly UserTestData _userTestData;

        public LoginSteps(UserTestData userTestData)
        {
            _userTestData = userTestData;
        }

        [Given(@"Login page is opened")]
        public void GivenLoginPageIsOpened()
        {
            _loginPage = new LoginPage(Hook.Driver);
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