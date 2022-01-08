using OpenQA.Selenium;

namespace ExamBasicAutomation.Pages
{
    public class ProductPage : BasePage
    {
        private static readonly By _addToCartButton = By.CssSelector("#add_to_cart button[type='submit']");

        public ProductPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public AddToCartOverlay ClickAddToCartButton()
        {
            WaitForElementToLoad(_addToCartButton, Timeout30Seconds);
            Click(_addToCartButton);
            return new AddToCartOverlay(_driver);
        } 
    }
}
