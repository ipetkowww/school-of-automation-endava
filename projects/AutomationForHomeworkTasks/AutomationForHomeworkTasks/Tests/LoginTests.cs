using AutomationForHomeworkTasks.Config;
using AutomationForHomeworkTasks.Constants;
using AutomationForHomeworkTasks.Pages;
using AutomationForHomeworkTasks.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static NUnit.Framework.Assert;

namespace AutomationForHomeworkTasks.Tests
{
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigProvider.GetConfigValue[StringConstants.Url]);
            _loginPage = new(_driver);
        }

        [Test]
        public void SuccessfulLoginWithValidCredentials()
        {
            string email = UserTestData.ValidEmail;

            _loginPage.FillEmailAddress(email);
            _loginPage.FillPassword(UserTestData.ValidPassword);

            HomePage homePage = _loginPage.ClickLoginButton();
            string actualLoggedInfo = homePage.GetLoggedInfo().Trim();
            string expectedLoggedInfo = $"Logged in: {email}";

            AreEqual(expectedLoggedInfo, actualLoggedInfo, "Logged Info Incorrect!");
        }

        [Test]
        [TestCase(UserTestData.InvalidEmail, UserTestData.ValidPassword)]
        [TestCase(UserTestData.ValidEmail, UserTestData.InvalidPassword)]
        public void TryToLoginWithInvalidCredentials(string email, string password)
        {
            _loginPage.FillEmailAddress(email);
            _loginPage.FillPassword(password);
            _loginPage.ClickLoginButton();

            bool isErrorDisplayed = _loginPage.IsErrorMessageDisplayed();
            string actualTextOfErrorMessage = _loginPage.GetErrorMessageText();

            IsTrue(isErrorDisplayed, "Error message was not displayed.");
            AreEqual("Invalid user or email", actualTextOfErrorMessage, "Text of error message is not correct.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
