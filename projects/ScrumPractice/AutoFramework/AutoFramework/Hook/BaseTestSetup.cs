using System;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;

namespace AutoFramework.Hook
{
    [Binding]
    public class BaseTestSetup
    {
        private static ExtentTest? _featureName;
        private static ExtentTest? _scenario;
        private static ExtentReports? _extent;

        [BeforeTestRun]
        public static void Setup()
        {
            InitializeExtentReport();
        }

        private static void InitializeExtentReport()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var htmlReporter =
                new AventStack.ExtentReports.Reporter.ExtentHtmlReporter(Path.Combine(path, "report", "ui",
                    "UITestReport.html"));
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDown()
        {
            _extent?.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName = _extent?.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenario = _featureName?.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var propertyInfo =
                typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            var getter = propertyInfo?.GetGetMethod(true);
            var testResult = getter?.Invoke(scenarioContext, null);
            var defaultNewLine = Environment.NewLine;
            var stepText = stepType + "\t" + scenarioContext.StepContext.StepInfo.Text;
            if (scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        _scenario?.CreateNode<Given>(stepText);
                        break;
                    case "When":
                        _scenario?.CreateNode<When>(stepText);
                        break;
                    case "Then":
                        _scenario?.CreateNode<Then>(stepText);
                        break;
                    case "And":
                        _scenario?.CreateNode<And>(stepText);
                        break;
                }
            }
            else if (scenarioContext.TestError != null)
            {
                var stepMessage = $"Message: {scenarioContext.TestError.Message}" + defaultNewLine;
                var stepStacktrace = $"Stacktrace: {scenarioContext.TestError.StackTrace}";
                var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromBase64String(
                    "Failed Test", scenarioContext.ScenarioInfo.Title.Trim()).Build();
                switch (stepType)
                {
                    case "Given":
                        _scenario?.CreateNode<Given>(stepText)
                            .Fail(stepMessage, mediaEntity)
                            .Fail(stepStacktrace);
                        break;
                    case "When":
                        _scenario?.CreateNode<When>(stepText)
                            .Fail(stepMessage, mediaEntity)
                            .Fail(stepStacktrace);
                        break;
                    case "Then":
                        _scenario?.CreateNode<Then>(stepText)
                            .Fail(stepMessage, mediaEntity)
                            .Fail(stepStacktrace);
                        break;
                    case "And":
                        _scenario?.CreateNode<And>(stepText)
                            .Fail(stepMessage, mediaEntity)
                            .Fail(stepStacktrace);
                        break;
                }
            }

            if (testResult?.ToString() == "StepDefinitionPending")
            {
                var stepPendingText = "Step definition pending";
                switch (stepType)
                {
                    case "Given":
                        _scenario?.CreateNode<Given>(stepText)
                            .Skip(stepPendingText);
                        break;
                    case "When":
                        _scenario?.CreateNode<When>(stepText)
                            .Skip(stepPendingText);
                        break;
                    case "Then":
                        _scenario?.CreateNode<Then>(stepText)
                            .Skip(stepPendingText);
                        break;
                    case "And":
                        _scenario?.CreateNode<And>(stepText)
                            .Skip(stepPendingText);
                        break;
                }
            }
        }
    }
}