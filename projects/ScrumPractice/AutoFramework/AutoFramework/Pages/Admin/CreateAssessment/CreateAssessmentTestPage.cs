using OpenQA.Selenium;

namespace AutoFramework.Pages.Admin.CreateAssessment
{
    public class CreateAssessmentTestPage : BasePage
    {
        private static readonly By Title = By.CssSelector("#id_title");
        private static readonly By Duration = By.CssSelector("#id_duration");
        private static readonly By SaveButton = By.CssSelector("input[name*='save']");
        private static readonly By SaveAndAddAnotherButton = By.CssSelector("input[name*='addanother']");
        private static readonly By SaveAndContinueEditingButton = By.CssSelector("input[name*='continue']");
        private static readonly By CorrectTheError = By.CssSelector(".errornote");
        private static readonly By IncorrectRangeError = By.CssSelector("[class*='field-duration'] .errorlist li");
        private static readonly By QuestionSection = By.CssSelector("#questions-group");
        private static readonly By ChooseAllButton = By.CssSelector("#id_technologies_add_all_link");
        private readonly QuestionSection _questionSection;

        public CreateAssessmentTestPage(IWebDriver driver) : base(driver)
        {
            _questionSection = new QuestionSection(driver);
        }

        public void FillTitle(string title)
        {
            WaitForElementToLoad(Title, Timeout10Seconds);
            FillTextInElement(Title, title);
        }

        public void FillDuration(int duration)
        {
            FillTextInElement(Duration, duration.ToString());
        }

        public void ClickSaveButton()
        {
            Click(SaveButton);
        }

        public bool IsCorrectTheErrorBelowMessageDisplayed()
        {
            return IsElementDisplayed(CorrectTheError);
        }

        public bool IsFieldRequiredErrorDisplayedFor(string fieldName)
        {
            string requiredFieldErrorLocator = $"[class*='field-{fieldName.ToLower()}'] .errorlist li";
            return IsElementDisplayed(By.CssSelector(requiredFieldErrorLocator));
        }

        public string GetErrorMessageTextForValueNotInRange()
        {
            WaitForElementToLoad(IncorrectRangeError, Timeout10Seconds);
            return GetElementText(IncorrectRangeError);
        }

        public bool IsFieldDisplayed(string fieldName)
        {
            return IsElementDisplayed(By.CssSelector($"[class*='field-{fieldName.ToLower()}']"));
        }

        public bool IsQuestionSectionDisplayed()
        {
            return IsElementDisplayed(QuestionSection);
        }

        public bool IsSaveAndAddAnotherButtonIsDisplayed()
        {
            return IsElementDisplayed(SaveAndAddAnotherButton);
        }
        
        public bool IsSaveAndContinueEditingButtonIsDisplayed()
        {
            return IsElementDisplayed(SaveAndContinueEditingButton);
        }
        
        public bool IsSaveButtonDisplayed()
        {
            return IsElementDisplayed(SaveButton);
        }

        public bool IsAddAnotherButtonDisplayedForQuestionSection()
        {
            return _questionSection.IsAddAnotherButtonDisplayed();
        }

        public bool IsChooseAllButtonDisplayed()
        {
            return IsElementDisplayed(ChooseAllButton);
        }
    }
}