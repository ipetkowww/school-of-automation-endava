using AutoFramework.Pages.Admin;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutoFramework.Steps.Admin
{
    [Binding]
    public class AssessmentTestSteps
    {
        private readonly AssessmentTestsPage _assessmentTestsPage;
        private readonly ScenarioContext _scenarioContext;

        public AssessmentTestSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _assessmentTestsPage = new AssessmentTestsPage(driver);
            _scenarioContext = scenarioContext;
        }
        
        
        [Then(@"The admin verifies that assessment test with name ""(.*)"" is successfully created")]
        public void ThenTheAdminVerifiesThatAssessmentTestWithNameIsSuccessfullyCreated(string testAssessmentName)
        {
            bool isMessageDisplayed = _assessmentTestsPage.IsSuccessMessageDisplayed();
            var successMessageText = _assessmentTestsPage.GetSuccessMessageText();
            Assert.IsTrue(isMessageDisplayed, "Test Assessment is not created successfully");
            Assert.IsTrue(successMessageText.Contains(testAssessmentName), 
                $"{testAssessmentName} assessment is not created");
            _scenarioContext.Add("testAssessmentForDeletion", testAssessmentName);
            
            // delete created Assessment in order to clear the created test data
            // TODO : Ask Yoan for best practice/approach to delete created data in After method in Hook
            ThenTheAdminDeletesAssessmentTestWithName(testAssessmentName);
        }

        [Then(@"The admin deletes assessment test with name ""(.*)""")]
        public void ThenTheAdminDeletesAssessmentTestWithName(string testAssessmentName)
        {
            _assessmentTestsPage.Delete(testAssessmentName);
        }
    }
}