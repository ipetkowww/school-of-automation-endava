using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FinalExam.Hooks
{
    [Binding]
    public class Hook
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver;

        public Hook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario("ui")]
        public void BeforeScenario()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs(_driver);
        }

        [AfterScenario("ui")]
        public void AfterScenario()
        {
            _driver!.Dispose();
        }
    }
}