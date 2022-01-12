using AutomationForHomeworkTasks.UIElements;
using OpenQA.Selenium;

namespace AutomationForHomeworkTasks.Pages
{
    internal class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterFirstName(string firstName)
        {
            WaitForElementToLoad(RegisterPageUIElements.FirstName, Timeout10Seconds);
            FillTextInElement(RegisterPageUIElements.FirstName, firstName);
        }

        public void EnterSirName(string sirName)
        {
            FillTextInElement(RegisterPageUIElements.SirName, sirName);
        }

        public void EnterEmail(string email)
        {
            FillTextInElement(RegisterPageUIElements.Email, email);
        }

        public void EnterPassword(string password)
        {
            FillTextInElement(RegisterPageUIElements.Password, password);
        }

        public void EnterCountry(string country)
        {
            FillTextInElement(RegisterPageUIElements.Country, country);
        }

        public void EnterCity(string city)
        {
            FillTextInElement(RegisterPageUIElements.City, city);
        }

        public void ClickAgreeTermsOfService()
        {
            Click(RegisterPageUIElements.AgreeTermsOfService);
        }

        public void ClickRegisterButton()
        {
            Click(RegisterPageUIElements.RegisterButton);
        }
    }
}
