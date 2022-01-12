using AutomationForHomeworkTasks.UIElements;
using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillEmailAddress(string email)
        {
            FillTextInElement(LoginPageUIElements.EmailField, email);
        }

        public void FillPassword(string password)
        {
            FillTextInElement(LoginPageUIElements.PasswordField, password);
        }

        public void ClickLoginButton()
        {
            Click(LoginPageUIElements.LoginButton);
        }

        public bool IsErrorMessageDisplayed()
        {
            WaitForElementToLoad(LoginPageUIElements.ErrorMessage, Timeout10Seconds);
            return FindElement(LoginPageUIElements.ErrorMessage).Displayed;
        }

        public string GetErrorMessageText()
        {
            WaitForElementToLoad(LoginPageUIElements.ErrorMessage, Timeout10Seconds);
            return GetElementText(LoginPageUIElements.ErrorMessage);
        }
    }
}