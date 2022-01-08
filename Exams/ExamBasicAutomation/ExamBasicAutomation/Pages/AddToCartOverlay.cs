using OpenQA.Selenium;

namespace ExamBasicAutomation.Pages
{
    public class AddToCartOverlay : BasePage
    {
        private static readonly By _addToCartOverlay = By.CssSelector("#layer_cart");
        private static readonly By _proceedToCheckoutButton = By.CssSelector(".layer_cart_cart a[title*='Proceed']");


        public AddToCartOverlay(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public ShoppingCartPage ClickProceedToCheckoutButton()
        {
            WaitForElementToLoad(_addToCartOverlay, Timeout30Seconds);
            WaitForElementToLoad(_proceedToCheckoutButton, Timeout30Seconds);
            WaitForElementToBeClickable(_proceedToCheckoutButton, Timeout30Seconds);
            Click(_proceedToCheckoutButton);
            return new ShoppingCartPage(_driver);
        }
    }
}
