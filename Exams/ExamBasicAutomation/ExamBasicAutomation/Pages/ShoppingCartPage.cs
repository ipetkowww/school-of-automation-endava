using OpenQA.Selenium;

namespace ExamBasicAutomation.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private static readonly By _addedProduct = By.CssSelector("#cart_summary tbody tr");
        private static readonly By _warningMessage = By.CssSelector("p[class*='alert-warning']");

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;   
        }

        public int GetAddedProductCount()
        {
            return FindElements(_addedProduct).Count;
        }

        public void DeleteProduct(string productName)
        {
            By productSelector = GetProductSelector(productName);
            WaitForElementToLoad(_addedProduct, Timeout30Seconds);
            WaitForElementToBeClickable(productSelector, Timeout30Seconds);
            WaitForElementToLoad(productSelector, Timeout30Seconds);
            WaitForElementToBeClickable(productSelector, Timeout30Seconds);
            Click(productSelector);
            WaitForElementToDissapear(productSelector, Timeout30Seconds);
        }

        public bool IsEmpty()
        {
            WaitForElementToLoad(_warningMessage, Timeout30Seconds);
            return IsElementDisplayed(_warningMessage);
        }

        private By GetProductSelector(string productName)
        {
            return By.XPath($"//p[@class='product-name']//a[text()='{productName}']/parent::p/parent::td/following-sibling::*[@data-title='Delete']//a");
        }
    }
}
