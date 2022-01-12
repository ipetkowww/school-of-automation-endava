using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.UIElements
{
    public class RegisterPageUIElements
    {
        public static readonly By FirstName = By.CssSelector("input[name='first_name']");
        public static readonly By SirName = By.CssSelector("input[name='sir_name']");
        public static readonly By Email = By.CssSelector("input[name='email']");
        public static readonly By Password = By.CssSelector("input[name='pass']");
        public static readonly By Country = By.CssSelector("input[name='country']");
        public static readonly By City = By.CssSelector("#city");
        public static readonly By AgreeTermsOfService = By.CssSelector("#TOS");
        public static readonly By RegisterButton = By.CssSelector("#reg");
    }
}