using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationForHomeworkTasks.Steps.Hooks
{
    [Binding]
    public class Hook
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                _driver.Dispose();
            }
        }
    }
}