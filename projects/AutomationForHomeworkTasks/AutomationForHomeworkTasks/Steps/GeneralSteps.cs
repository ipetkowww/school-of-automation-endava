using AutomationForHomeworkTasks.Pages;
using AutomationForHomeworkTasks.Steps.Hooks;
using TechTalk.SpecFlow;

namespace AutomationForHomeworkTasks.Steps
{
    [Binding]
    public class GeneralSteps
    {
        private readonly BasePage _basePage;

        public GeneralSteps()
        {
            _basePage = new BasePage(Hook.Driver);
        }

        [Given(@"""([^""]*)"" page is opened")]
        public void GivenPageIsOpened(string pageName)
        {
            _basePage.OpenPage(pageName);
        }
    }
}
