using AutomationForHomeworkTasks.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationForHomeworkTasks.Steps
{
    [Binding]
    public class GeneralSteps
    {
        private readonly IWebDriver _driver;
        private readonly BasePage _basePage;

        public GeneralSteps() { }

        public GeneralSteps(IWebDriver driver)
        {
            _driver = driver;
            _basePage = new BasePage(_driver);
        }

        [Given(@"""([^""]*)"" page is opened")]
        public void GivenPageIsOpened(string pageName)
        {
            _basePage.OpenPage(pageName);
        }
    }
}