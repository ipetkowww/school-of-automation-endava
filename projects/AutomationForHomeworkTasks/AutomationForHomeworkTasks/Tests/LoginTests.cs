using AutomationForHomeworkTasks.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationForHomeworkTasks.Tests
{
    public class LoginTests
    {
        private static readonly string URL = "http://localhost:8080";
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void SuccessfulLoginWithValidCredentials()
        {
            string email = "admin@automation.com";
            string password = "pass123";

            LoginPage loginPage = new(_driver);
            loginPage.FillEmailAddress(email);
            loginPage.FillPassword(password);

            HomePage homePage = loginPage.ClickLoginButton();
            string actualLoggedInfo = homePage.GetLoggedInfo().Trim();
            string expectedLoggedInfo = $"Logged in: {email}";

            Assert.AreEqual(expectedLoggedInfo, actualLoggedInfo, "Logged Info Incorrect!");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
