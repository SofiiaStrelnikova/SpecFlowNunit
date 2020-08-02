using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowNunit
{
    public class SentPage : BasePage
    {
        private BaseElement currentLetterInSents => new BaseElement(By.XPath(ForLetterConunter.XPathBuilder("//a[@href=\"/lite/thread/", (ForLetterConunter.LetterCounter + 1).ToString(), "/new\"]")));
        private BaseElement allLettersChoose => new BaseElement(By.Id("check-all"));
        private BaseElement allLettersDelete => new BaseElement(By.XPath("//input[@value=\"Удалить\"]"));
        private BaseElement anyLetter => new BaseElement(By.ClassName("b-messages__from"));


        public void ClearSents()
        {
            allLettersChoose.Click();
            allLettersDelete.Click();
            Assert.IsFalse(anyLetter.FindElements().Count > 0);
        }

        public void LetterInSentsAfterSendingCheck()
        {
            Assert.IsTrue(currentLetterInSents.FindElements().Count > 0);
        }
    }
}
