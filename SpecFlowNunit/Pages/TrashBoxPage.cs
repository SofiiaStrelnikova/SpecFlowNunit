using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowNunit
{
    public class TrashBoxPage : BasePage
    {
        private BaseElement allLettersChoose => new BaseElement(By.Id("check-all"));
        private BaseElement allLettersDelete => new BaseElement(By.XPath("//input[@value=\"Удалить\"]"));
        private BaseElement anyLetter => new BaseElement(By.ClassName("b-messages__from"));
        public void ClearTrashBox()
        {
            allLettersChoose.Click();
            allLettersDelete.Click();
            Assert.IsFalse(anyLetter.FindElements().Count > 0);
        }
    }
}
