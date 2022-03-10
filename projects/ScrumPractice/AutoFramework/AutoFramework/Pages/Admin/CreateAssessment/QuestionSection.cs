using OpenQA.Selenium;

namespace AutoFramework.Pages.Admin.CreateAssessment
{
    public class QuestionSection : BasePage
    {
        private static readonly By AddAnotherButtonInQuestionSection =
            By.CssSelector("[class='djn-add-item'] a[class*='endavaIntership-question']");

        private static readonly By TextArea = By.CssSelector("#id_questions-0-text");
        private static readonly By ImageField = By.CssSelector("#id_questions-0-image");
        private static readonly By DeleteQuestionButton = By.CssSelector(".delete [class*='Intership-question']");

        private static readonly By Answer = By.CssSelector("tbody[class*='Intership-answer']");
        //////a[contains(text(), 'Add another') and contains(@class, 'Intership-question')]

        public QuestionSection(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAnotherButton()
        {
            Click(AddAnotherButtonInQuestionSection);
        }

        public bool IsQuestionTextFieldDisplayed()
        {
            return IsElementDisplayed(TextArea);
        }

        public bool IsUploadImageButtonDisplayed()
        {
            return IsElementDisplayed(ImageField);
        }

        public bool IsDeleteQuestionButtonDisplayed()
        {
            return IsElementDisplayed(DeleteQuestionButton);
        }

        public int GetAnswersCount()
        {
            return FindElements(Answer).Count;
        }

        public void IsEachAnswerContainsCorrectElements()
        {
            for (var i = 0; i < FindElements(Answer).Count; i++)
            {
                VerifyWebElementIsVisible(By.CssSelector($"#id_questions-0-answers-{i}-text"),
                    $"Answer text field is not displayed for answer option {i + 1}");
                VerifyWebElementIsVisible(By.CssSelector($"#id_questions-0-answers-{i}-is_correct"),
                    $"Is Correct checkbox is not displayed for answer option {i + 1}");
                VerifyWebElementIsVisible(By.XPath("//a[text()='Remove' and contains(@class, 'Intership-answer')]"),
                    $"Delete button is not displayed for answer option {i + 1}");
            }
        }

        public bool IsAddAnotherButtonDisplayed()
        {
            return IsElementDisplayed(AddAnotherButtonInQuestionSection);
        }
    }
}