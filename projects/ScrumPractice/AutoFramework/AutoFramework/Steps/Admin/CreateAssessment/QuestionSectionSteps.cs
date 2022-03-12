using AutoFramework.Pages.Admin.CreateAssessment;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutoFramework.Steps.Admin.CreateAssessment
{
    [Binding]
    public class QuestionSectionSteps
    {
        private readonly QuestionSection _questionSection;

        public QuestionSectionSteps(IWebDriver driver)
        {
            _questionSection = new QuestionSection(driver);
        }
        
        [When(@"The user clicks on Add another button in Question section")]
        public void WhenTheUserClicksOnAddAnotherButtonInQuestionSection()
        {
            _questionSection.ClickAnotherButton();
        }

        [Then(@"Question text field is displayed")]
        public void ThenQuestionTextFieldIsDisplayed()
        {
            Assert.IsTrue(_questionSection.IsQuestionTextFieldDisplayed(), "Question text field is not displayed");
        }

        [Then(@"Upload image button is displayed")]
        public void ThenUploadImageButtonIsDisplayed()
        {
            Assert.IsTrue(_questionSection.IsUploadImageButtonDisplayed(), "Upload image button is not displayed");
        }

        [Then(@"Delete question button is displayed")]
        public void ThenDeleteQuestionButtonIsDisplayed()
        {
            Assert.IsTrue(_questionSection.IsDeleteQuestionButtonDisplayed(), 
                "Delete button for question is not displayed");
        }

        [Then(@"The question has (.*) answers available")]
        public void ThenTheQuestionHasAnswersAvailable(int answersCount)
        {
            var defaultAnswersCount = _questionSection.GetAnswersCount();
            Assert.AreEqual(answersCount, defaultAnswersCount, 
                $"Answer count is not correct. It should be {answersCount} but it is {defaultAnswersCount}");
        }

        [Then(@"Each answer has input text field with corresponding 'Is Correct' check-box and delete button")]
        public void ThenEachAnswerHasInputTextFieldWithCorrespondingCheckBoxAndDeleteButton()
        {
            _questionSection.IsEachAnswerContainsCorrectElements();
        }

        [When(@"The user clicks on Delete button in Question section")]
        public void WhenTheUserClicksOnDeleteButtonInQuestionSection()
        {
            _questionSection.DeleteQuestion();
        }

        [Then(@"The question is deleted successfully")]
        public void ThenTheQuestionIsDeletedSuccessfully()
        {
            Assert.IsFalse(_questionSection.IsDeleteQuestionButtonDisplayed(), 
                "The question is not deleted.");
        }

        [When(@"The user clicks on Add another button for an Answer")]
        public void WhenTheUserClicksOnAddAnotherButtonForAnAnswer()
        {
            _questionSection.AddAnotherAnswer();
        }
    }
}