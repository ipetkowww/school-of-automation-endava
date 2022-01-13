using AutomationForHomeworkTasks.Constants;
using AutomationForHomeworkTasks.Helpers;
using AutomationForHomeworkTasks.Pages;
using AutomationForHomeworkTasks.TestData;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationForHomeworkTasks.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private readonly RegisterPage _registerPage;
        private UserTestData _userTestData;

        public RegisterSteps(IWebDriver driver, ScenarioContext scenarioContext, UserTestData userTestData)
        {
            _driver = driver;
            _registerPage = new RegisterPage(_driver);
            _scenarioContext = scenarioContext;
            _userTestData = userTestData;
        }

        [When(@"The user fills following data for registration:")]
        public void WhenTheUserFillsFollowingDataForRegistration(Table table)
        {
            _userTestData = table.CreateInstance<UserTestData>();
            if (_userTestData.Email == StringConstants.RandomEmail)
            {
                _userTestData.Email = $"reg_email{Helper.GetAlphaNumericString()}@autotest.com";
            }
            _scenarioContext.Add("userForRegistration", _userTestData);
            _registerPage.EnterFirstName(_userTestData.FirstName);
            _registerPage.EnterSirName(_userTestData.SirName);
            _registerPage.EnterEmail(_userTestData.Email);
            _registerPage.EnterPassword(_userTestData.Password);
            _registerPage.EnterCountry(_userTestData.Country);
            _registerPage.EnterCity(_userTestData.City);
        }

        [When(@"The user clicks on agree with terms of service")]
        public void WhenTheUserClickOnAgreeWithTermsOfService()
        {
            _registerPage.ClickAgreeTermsOfService();
        }

        [When(@"The user clicks on Register button")]
        public void WhenTheUserClicksOnRegisterButton()
        {
            _registerPage.ClickRegisterButton();
        }
    }
}