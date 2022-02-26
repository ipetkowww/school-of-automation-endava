using FinalExam.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FinalExam.Steps.UI
{
    [Binding]
    public class GeneralSteps
    {
        private readonly BasePage _basePage;

        public GeneralSteps(IWebDriver driver)
        {
            _basePage = new BasePage(driver);
        }

        [Given(@"""([^""]*)"" page is opened")]
        [When(@"""([^""]*)"" page is opened")]
        public void GivenPageIsOpened(string pageName)
        {
            _basePage.OpenPage(pageName);
        }
    }
}