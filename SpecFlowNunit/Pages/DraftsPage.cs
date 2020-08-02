using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowNunit
{
    public class DraftsPage : BasePage
    {
        private BaseElement currentDraft => new BaseElement(By.XPath(ForLetterConunter.XPathBuilder("//a[@href=\"/lite/compose/", ForLetterConunter.LetterCounter.ToString(), "/draft=true\"]")));

        public void DraftClickAndCheck()
        {
            Assert.IsTrue(currentDraft.FindElements().Count > 0);
            currentDraft.Click();
        }
    }
}
