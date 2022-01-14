using AutomationForHomeworkTasks.Constants;
using AutomationForHomeworkTasks.Helpers;
using AutomationForHomeworkTasks.Pages;
using AutomationForHomeworkTasks.TestData;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static NUnit.Framework.Assert;

namespace AutomationForHomeworkTasks.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private readonly IWebDriver _driver;
        private readonly RegisterPage _registerPage;
        private readonly UserTestData _userTestData;

        public RegisterSteps(IWebDriver driver, UserTestData userTestData)
        {
            _driver = driver;
            _registerPage = new RegisterPage(_driver);
            _userTestData = userTestData;
        }

        [When(@"The user fills following data for registration:")]
        public void WhenTheUserFillsFollowingDataForRegistration(Table table)
        {
            UserTestData currentUser = table.CreateInstance<UserTestData>();
            if (currentUser.Email == StringConstants.RandomEmail)
            {
                currentUser.Email = $"reg_email{Helper.GetAlphaNumericString()}@autotest.com";
            }
            _registerPage.EnterFirstName(currentUser.FirstName);
            _registerPage.EnterSirName(currentUser.SirName);
            _registerPage.EnterEmail(currentUser.Email);
            _registerPage.EnterPassword(currentUser.Password);
            _registerPage.EnterCountry(currentUser.Country);
            _registerPage.EnterCity(currentUser.City);
            _registerPage.SelectTitle(currentUser.Title);

            _userTestData.Title = currentUser.Title;
            _userTestData.FirstName = currentUser.FirstName;
            _userTestData.SirName = currentUser.SirName;
            _userTestData.Email = currentUser.Email;
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

        [Then(@"The error message for already existing email is displayed")]
        public void ThenTheErrorMessageForAlreadyExistingEmailIsDisplayed()
        {
            IsTrue(_registerPage.IsAlreadyExistingMailErrorDisplayed(), "Error for already existing email is not displayed");
        }
    }
}