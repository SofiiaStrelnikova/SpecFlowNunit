using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowNunit
{
    public class CurrentDraftLetterPage : BasePage
    {
        private BaseElement toFieldInDraftLetter => new BaseElement(By.Name("to"));
        private BaseElement themeFieldInDraftLetter => new BaseElement(By.Name("subj"));
        private BaseElement textFieldInDraftLetter => new BaseElement(By.Name("send"));
        private BaseElement sendButton => new BaseElement(By.Name("doit"));

        public void CheckLetter(string Email, string Theme, string Letter)
        {
            Assert.IsTrue(toFieldInDraftLetter.GetAttribute("value").Contains(Email));

            Assert.IsTrue(themeFieldInDraftLetter.GetAttribute("value").Contains(Theme));

            Assert.IsTrue(textFieldInDraftLetter.GetAttribute("value").Contains(Letter));
        }

        public void SendLetter()
        {
            sendButton.Click();
        }


    }
}
