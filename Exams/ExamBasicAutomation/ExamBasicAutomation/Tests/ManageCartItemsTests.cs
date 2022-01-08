using ExamBasicAutomation.TestData;
using ExamBaiscAutomation.Pages;
using ExamBasicAutomation.Configuration;
using ExamBasicAutomation.Constants;
using ExamBasicAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static NUnit.Framework.Assert;

namespace ExamBasicAutomation.Tests
{
    public class ManageCartItemsTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(ConfigurationProvider.GetConfigValue[AppConstants.HomePageURL]);
            _homePage = new(_driver);
        }

        [Test]
        public void AddOneItemToTheCart()
        {
            ProductPage productPage = _homePage.ClickOnProduct(UserTestData.BlouseProduct);
            AddToCartOverlay addToCartOverlay = productPage.ClickAddToCartButton();
            ShoppingCartPage shoppingCartPage = addToCartOverlay.ClickProceedToCheckoutButton();

            int expectedAddedProductsCount = 1;
            int actualAddedProductsCount = shoppingCartPage.GetAddedProductCount();

            AreEqual(actualAddedProductsCount, expectedAddedProductsCount, "Product count in Shopping Cart page is not correct");
        }

        [Test]
        public void DeleteItemFromCart()
        {
            ProductPage productPage = _homePage.ClickOnProduct(UserTestData.BlouseProduct);
            AddToCartOverlay addToCartOverlay = productPage.ClickAddToCartButton();
            ShoppingCartPage shoppingCartPage = addToCartOverlay.ClickProceedToCheckoutButton();

            shoppingCartPage.DeleteProduct(UserTestData.BlouseProduct);

            IsTrue(shoppingCartPage.IsEmpty(), "Shopping Cart is not empty but it should be.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
