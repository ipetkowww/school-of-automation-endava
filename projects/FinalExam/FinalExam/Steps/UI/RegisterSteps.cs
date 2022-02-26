using FinalExam.Constants;
using FinalExam.Pages;
using FinalExam.TestData;
using FinalExam.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FinalExam.Steps.UI
{
    [Binding]
    public class RegisterSteps
    {
        private readonly RegisterPage _registerPage;
        private readonly UserTestData _userTestData;
        private readonly GeneralSteps _generalSteps;

        public RegisterSteps(IWebDriver driver, UserTestData userTestData)
        {
            _registerPage = new RegisterPage(driver);
            _userTestData = userTestData;
            _generalSteps = new GeneralSteps(driver);
        }

        [Given(@"The uer with following data is created:")]
        public void GivenTheUerWithFollowingDataIsAlreadyCreated(Table table)
        {
            _generalSteps.GivenPageIsOpened("Register");
            WhenTheUserFillsFollowingDataForRegistration(table);
            WhenTheUserClicksOnRegisterButton();
        }

        [When(@"The user fills following data for registration:")]
        public void WhenTheUserFillsFollowingDataForRegistration(Table table)
        {
            var currentUser = table.CreateInstance<UserTestData>();
            if (currentUser.Username == AppConstants.RandomUsername)
            {
                currentUser.Username = $"Ivan{Helper.GetAlphaNumericString()}";
            }
            _registerPage.EnterFirstName(currentUser.FirstName!);
            _registerPage.EnterLastName(currentUser.LastName!);
            _registerPage.EnterAddress(currentUser.Address!);
            _registerPage.EnterCity(currentUser.City!);
            _registerPage.EnterState(currentUser.State!);
            _registerPage.EnterZipcode(currentUser.Zipcode!);
            _registerPage.EnterSSN(currentUser.SSN!);
            _registerPage.EnterUsername(currentUser.Username!);
            _registerPage.EnterPassword(currentUser.Password!);
            _registerPage.EnterConfirmPassword(currentUser.Confirm!);

            _userTestData.FirstName = currentUser.FirstName;
            _userTestData.LastName = currentUser.LastName;
            _userTestData.Address = currentUser.Address;
            _userTestData.City = currentUser.City;
            _userTestData.State = currentUser.State;
            _userTestData.Zipcode = currentUser.Zipcode;
            _userTestData.SSN = currentUser.SSN;
            _userTestData.Username = currentUser.Username;
            _userTestData.Password = currentUser.Password;
            _userTestData.Confirm = currentUser.Confirm;
        }

        [When(@"The user clicks on Register button")]
        public void WhenTheUserClicksOnRegisterButton()
        {
            _registerPage.ClickRegisterButton();
        }

        [Then(@"The user is successfully registered")]
        public void ThenTheUserIsSuccessfullyRegistered()
        {
            var welcomeTitle = _registerPage.GetWelcomeTitle();
            var expectedWelcomeTitle = $"Welcome {_userTestData.Username}";
            var successfulRegistrationMessage = _registerPage.GetSuccessfulRegistrationMessage();

            Assert.AreEqual(welcomeTitle, expectedWelcomeTitle, "Username in welcome title is not correct.");
            Assert.IsTrue(successfulRegistrationMessage.Contains("account was created successfully"),
                "Account was not created");
        }

        [Given(@"The user log outs from the system")]
        public void GivenTheUserLogOutsFromTheSystem()
        {
            _registerPage.AccountServicesSection.ClickLogOutButton();
        }
    }
}