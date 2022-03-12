using OpenQA.Selenium;

namespace AutoFramework.Pages.Admin
{
    public class IntershipAdministrationPage : BasePage
    {
        
        public IntershipAdministrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAddButtonFor(string fieldName)
        {
            string addButtonLocator = $"//a[text()='{fieldName}']/parent::th/following-sibling::td/a";
            Click(By.XPath(addButtonLocator));
        }
    }
}