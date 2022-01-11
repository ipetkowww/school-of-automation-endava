using AutomationForHomeworkTasks.Pages;
using AutomationForHomeworkTasks.Steps.Hooks;
using AutomationForHomeworkTasks.TestData;
using TechTalk.SpecFlow;
using static NUnit.Framework.Assert;

namespace AutomationForHomeworkTasks.Steps
{
    [Binding]
    public class HomeSteps
    {
        private readonly HomePage _homePage;
        private readonly UserTestData _userTestData;

        public HomeSteps(UserTestData userTestData)
        {
            _homePage = new HomePage(Hook.Driver);
            _userTestData = userTestData;
        }

        [Then(@"The user is logged in successfully")]
        public void ThenTheUserIsLoggedInSuccessfully()
        {
            string actualLoggedInfo = _homePage.GetLoggedInfo().Trim();
            string expectedLoggedInfo = $"Logged in: {_userTestData.Email}";
            AreEqual(expectedLoggedInfo, actualLoggedInfo, "Logged Info Incorrect!");
        }
    }
}