using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.UIElements
{
    public class HomePageUIElements
    {
        public static readonly By LoggedInInfo = By.CssSelector(".dropdown-toggle");
        public static readonly By ErrorMessage = By.CssSelector(".alert-danger");
        public static readonly By UserTitleAndName = By.CssSelector(".jumbotron h1");
    }
}