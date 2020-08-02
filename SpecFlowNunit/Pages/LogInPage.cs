using OpenQA.Selenium;

namespace SpecFlowNunit
{
    public class LogInPage : BasePage
    {
        private BaseElement enterButtonOnMainPage => new BaseElement(By.XPath("//a[@data-reactid=\"24\"]"));

        private BaseElement emailField => new BaseElement(By.Id("passp-field-login"));

        private BaseElement enterButtonOnEnterFrame => new BaseElement(By.XPath("//button[@type=\"submit\"]"));

        private BaseElement passwordField => new BaseElement(By.Id("passp-field-passwd"));

        public void DoLogin(User user)
        {
            enterButtonOnMainPage.Click();            

            emailField.SendKeys(user.DataUser[0]);

            enterButtonOnEnterFrame.Click();

            passwordField.SendKeys(user.DataUser[1]);

            enterButtonOnEnterFrame.Click();
        }
    }
}
