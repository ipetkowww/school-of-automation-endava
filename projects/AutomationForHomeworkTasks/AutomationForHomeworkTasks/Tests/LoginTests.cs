using AutomationForHomeworkTasks.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static NUnit.Framework.Assert;

namespace AutomationForHomeworkTasks.Tests
{
    public class LoginTests
    {
        private static readonly string Url = "http://localhost:8080";
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Url);
            _loginPage = new(_driver);
        }

        [Test]
        public void SuccessfulLoginWithValidCredentials()
        {
            string email = "admin@automation.com";
            string password = "pass123";

            _loginPage.FillEmailAddress(email);
            _loginPage.FillPassword(password);

            HomePage homePage = _loginPage.ClickLoginButton();
            string actualLoggedInfo = homePage.GetLoggedInfo().Trim();
            string expectedLoggedInfo = $"Logged in: {email}";

            AreEqual(expectedLoggedInfo, actualLoggedInfo, "Logged Info Incorrect!");
        }

        [Test]
        [TestCase("invalidEmail@test.com", "pass123")]
        [TestCase("admin@automation.com", "invalidPassword")]
        public void TryToLoginWithInvalidCredentials(string email, string password)
        {
            _loginPage.FillEmailAddress(email);
            _loginPage.FillPassword(password);
            _loginPage.ClickLoginButton();

            bool isErrorDisplayed = _loginPage.IsErrorMessageDisplayed();
            string actualTextOfErrorMessage = _loginPage.GetErrorMessageText();
            string expectedTextOfErrorMessage = "Invalid user or email";

            IsTrue(isErrorDisplayed, "Error message was not displayed.");
            AreEqual(expectedTextOfErrorMessage, actualTextOfErrorMessage, "Text of error message is not correct.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
