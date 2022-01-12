using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.UIElements
{
    public class LoginPageUIElements
    {
        public static readonly By EmailField = By.CssSelector("input[type='email']");
        public static readonly By PasswordField = By.CssSelector("input[type='password']");
        public static readonly By LoginButton = By.CssSelector(".btn-primary");
        public static readonly By ErrorMessage = By.CssSelector(".alert-danger");
    }
}