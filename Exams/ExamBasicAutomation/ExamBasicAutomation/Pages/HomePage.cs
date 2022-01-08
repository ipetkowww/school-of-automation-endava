using OpenQA.Selenium;

namespace ExamBasicAutomation.Pages
{
    public class HomePage : BasePage
    {
        private static readonly By productContainer = By.CssSelector("#center_column");

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        internal ProductPage ClickOnProduct(string productName)
        {
            WaitForElementToLoad(productContainer, Timeout30Seconds);
            By productSelector = By.CssSelector($".product-container h5 a[title='{productName}']");
            Click(productSelector);
            return new ProductPage(_driver);
        }
    }
}
