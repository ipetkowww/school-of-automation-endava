using AutomationForHomeworkTasks.Config;
using AutomationForHomeworkTasks.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationForHomeworkTasks.Steps.Hooks
{
    [Binding]
    public class Hook
    {
        private static IWebDriver _driver;

        public  static IWebDriver Driver { get { return _driver; } }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigProvider.GetConfigValue[StringConstants.BaseUrl]);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            if (_driver != null)
            {
                _driver.Dispose();
            }
        }
    }
}