using OpenQA.Selenium;

namespace AutoFramework.Pages.Admin
{
    public class AssessmentTestsPage : BasePage
    {
        private static readonly By SuccessMessageField = By.CssSelector("li.success");
        
        public AssessmentTestsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsSuccessMessageDisplayed()
        {
            WaitForElementToLoad(SuccessMessageField, Timeout10Seconds);
            return IsElementDisplayed(SuccessMessageField);
        }

        public string GetSuccessMessageText()
        {
            return GetElementText(SuccessMessageField);
        }

        public void Delete(string testAssessmentName)
        {
            string deleteButtonLocator = $"//td[text()='{testAssessmentName}']/parent::tr//a[@class='deletelink']";
            Click(By.XPath(deleteButtonLocator));
        }

        public void ClickEditButtonForTestWithName(string testAssessmentName)
        {
            string editButtonLocator = $"//td[text()='{testAssessmentName}']/parent::tr//a[@class='changelink']";
            Click(By.XPath(editButtonLocator));
        }
    }
}