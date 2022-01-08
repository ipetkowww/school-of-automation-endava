using ExamBasicAutomation.TestData;
using ExamBaiscAutomation.Pages;
using ExamBasicAutomation.Configuration;
using ExamBasicAutomation.Constants;
using ExamBasicAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static NUnit.Framework.Assert;

namespace ExamBasicAutomation.Tests
{
    public class RegistrationTests
    {
        private IWebDriver _driver;
        private AuthenticationPage _authenticationPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationProvider.GetConfigValue[AppConstants.AuthenticationPageURL]);
            _authenticationPage = new(_driver);
        }

        [Test]
        public void SuccessfulRegistration()
        {
            _authenticationPage.EnterEmailInEmailField(UserTestData.RegistrationEmail);
            RegistrationPage registrationPage = _authenticationPage.ClickCreateAccountButton();
            registrationPage.EnterFirstName(UserTestData.FirstName);
            registrationPage.EnterLastName(UserTestData.LastName);
            registrationPage.EnterPassword(UserTestData.Password);
            registrationPage.EnterAddress(UserTestData.Address);
            registrationPage.EnterCity(UserTestData.City);
            registrationPage.SelectState(UserTestData.AlabamaState);
            registrationPage.EnterPostalCode(UserTestData.PostalCode);
            registrationPage.EnterMobilePhoneNumber(UserTestData.MobilePhoneNumber);
            registrationPage.EnterAddressAlias(UserTestData.AddressAlias);
            MyAccountPage myAccountPage = registrationPage.ClickRegisterButton();

            string actualFirstAndLastName = myAccountPage.getFirstAndLastName();
            string expectedFirstAndLastName = $"{UserTestData.FirstName} {UserTestData.LastName}";

            IsTrue(myAccountPage.IsDisplayed(), $"{AppConstants.MyAccountPageHeading} is not displayed");
            AreEqual(expectedFirstAndLastName, actualFirstAndLastName, "First Name and Last Name in header are not correct!");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
