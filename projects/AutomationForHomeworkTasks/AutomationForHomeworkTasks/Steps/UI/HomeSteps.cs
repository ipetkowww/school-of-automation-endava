using AutomationForHomeworkTasks.Pages;
using AutomationForHomeworkTasks.TestData;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static NUnit.Framework.Assert;

namespace AutomationForHomeworkTasks.Steps
{
    [Binding]
    public class HomeSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly UserTestData _userTestData;

        public HomeSteps(IWebDriver driver, UserTestData userTestData)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
            _userTestData = userTestData;
        }

        [Then(@"The user is logged in successfully")]
        public void ThenTheUserIsLoggedInSuccessfully()
        {
            string actualLoggedInfo = _homePage.GetLoggedInfo().Trim();
            string expectedLoggedInfo = $"Logged in: {_userTestData.Email}";
            AreEqual(expectedLoggedInfo, actualLoggedInfo, "Logged Info Incorrect.");
        }

        [Then(@"The user is successfully registered")]
        public void ThenTheUserIsSuccessfullyRegistered()
        {
            ThenTheUserIsLoggedInSuccessfully();
            string actualUserTitleAndName = _homePage.GetUserTitleAndName().Trim();
            string expectedUserTitleAndName = $"{_userTestData.Title} {_userTestData.FirstName} {_userTestData.SirName}";
            AreEqual(expectedUserTitleAndName, actualUserTitleAndName, "User title and name are not correct.");

        }
    }
}