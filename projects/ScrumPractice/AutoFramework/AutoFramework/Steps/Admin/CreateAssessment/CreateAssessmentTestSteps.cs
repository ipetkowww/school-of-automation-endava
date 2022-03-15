using AutoFramework.Constants;
using AutoFramework.Pages.Admin;
using AutoFramework.Pages.Admin.CreateAssessment;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutoFramework.Steps.Admin.CreateAssessment
{
    [Binding]
    public class CreateAssessmentTestSteps
    {
        private readonly CreateAssessmentTestPage _createAssessmentTestPage;
        private readonly IntershipAdministrationPage _intershipAdministrationPage;

        public CreateAssessmentTestSteps(IWebDriver driver)
        {
            _createAssessmentTestPage = new CreateAssessmentTestPage(driver);
            _intershipAdministrationPage = new IntershipAdministrationPage(driver);
        }
        
        [Given(@"Assessment with name ""(.*)"" is created")]
        public void GivenAssessmentWithNameIsCreated(string? testAssessmentName)
        {
            _intershipAdministrationPage.ClickAddButtonFor(EndavaInternshipFields.Tests);
            _createAssessmentTestPage.FillTitle(testAssessmentName);
            _createAssessmentTestPage.FillDuration(AppConstants.Duration);
            _createAssessmentTestPage.ClickSaveButton();
        }

        [When(@"The admin fills title ""(.*)""")]
        public void WhenTheAdminFillsTitle(string? title)
        {
            _createAssessmentTestPage.FillTitle(title);
        }

        [When(@"The admin fills number ""(.*)"" for duration")]
        public void WhenTheAdminFillsNumberForDuration(string duration)
        {
            _createAssessmentTestPage.FillDuration(int.Parse(duration));
        }

        [When(@"The admin clicks on SAVE button")]
        public void WhenTheAdminClicksOnSaveButton()
        {
            _createAssessmentTestPage.ClickSaveButton();
        }

        [Then(@"Please correct the error below message is displayed")]
        public void ThenPleaseCorrectTheErrorBelowMessageIsDisplayed()
        {
            var isErrorDisplayed = _createAssessmentTestPage.IsCorrectTheErrorBelowMessageDisplayed();
            Assert.IsTrue(isErrorDisplayed, "Please correct the error below. is not displayed");
        }

        [Then(@"This field is required error message is displayed for ""(.*)"" field")]
        public void ThenThisFieldIsRequiredErrorMessageIsDisplayedForField(string fieldName)
        {
            var isFieldRequiredErrorDisplayed = _createAssessmentTestPage.IsFieldRequiredErrorDisplayedFor(fieldName);
            Assert.IsTrue(isFieldRequiredErrorDisplayed,
                $"Required Field error message was not displayed for {fieldName} field.");
        }

        [Then(@"Ensure this value is less than or equal to (.*) error message is displayed")]
        public void ThenEnsureThisValueIsLessThanOrEqualToErrorMessageIsDisplayed(int durationValue)
        {
            string lessOrGrater;
            if (durationValue > 999)
            {
                durationValue -= (durationValue - 999);
                lessOrGrater = "less";
            }
            else
            {
                durationValue = 1;
                lessOrGrater = "greater";
            }

            var expectedErrorMessage = $"Ensure this value is {lessOrGrater} than or equal to {durationValue}.";
            var incorrectValueMessage = _createAssessmentTestPage.GetErrorMessageTextForValueNotInRange();
            Assert.AreEqual(expectedErrorMessage, incorrectValueMessage,
                $"Ensure this value is greater than or equal to ${durationValue}. error is not displayed");
        }

        [Then(@"""(.*)"" field is displayed")]
        public void ThenFieldIsDisplayed(string fieldName)
        {
            var isDisplayed = _createAssessmentTestPage.IsFieldDisplayed(fieldName);
            Assert.IsTrue(isDisplayed, $"{fieldName} is not displayed.");
        }

        [Then(@"Question section is displayed")]
        public void ThenQuestionSectionIsDisplayed()
        {
            Assert.IsTrue(_createAssessmentTestPage.IsQuestionSectionDisplayed(), "Question Section is not displayed.");
        }

        [Then(@"Save and add another button is displayed")]
        public void ThenSaveAndAddAnotherButtonIsDisplayed()
        {
            Assert.IsTrue(_createAssessmentTestPage.IsSaveAndAddAnotherButtonIsDisplayed(),
                "Save and add another button is not displayed");
        }

        [Then(@"Save and continue editing button is displayed")]
        public void ThenSaveAndContinueEditingButtonIsDisplayed()
        {
            Assert.IsTrue(_createAssessmentTestPage.IsSaveAndContinueEditingButtonIsDisplayed(),
                "Save and continue editing button is not displayed");
        }

        [Then(@"SAVE button is displayed")]
        public void ThenSaveButtonIsDisplayed()
        {
            Assert.IsTrue(_createAssessmentTestPage.IsSaveButtonDisplayed(),
                "SAVE button is not displayed");
        }

        [Then(@"Add another button button is displayed in Question section")]
        public void ThenAddAnotherButtonButtonIsDisplayedInQuestionSection()
        {
            Assert.IsTrue(_createAssessmentTestPage.IsAddAnotherButtonDisplayedForQuestionSection(),
                "Add another button is not displayed in Question section");
        }

        [Then(@"Choose all button is displayed")]
        public void ThenChooseAllButtonIsDisplayed()
        {
            Assert.IsTrue(_createAssessmentTestPage.IsChooseAllButtonDisplayed(), "Choose all button is not displayed");
        }
    }
}