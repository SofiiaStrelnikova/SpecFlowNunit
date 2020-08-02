using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowNunit
{
    public class PostPage : BasePage
    {
        private BaseElement drafts => new BaseElement(By.XPath("//span[contains(text(),\"Черновики\")]"));
        private BaseElement exitLink => new BaseElement(By.XPath("//a[contains(text(), \"Выход\")]"));

        private BaseElement lightPost => new BaseElement(By.XPath("//a[contains(text(), \"Лёгкая версия\")]"));

        private BaseElement disk => new BaseElement(By.XPath("//a[contains(text(), \"Диск\")]"));

        private BaseElement toTypeButton => new BaseElement(By.XPath("//i[contains(text(), \"Написать\")]"));

        private BaseElement sents => new BaseElement(By.XPath("//span[contains(text(), \"Отправленные\")]"));

        private BaseElement trash => new BaseElement(By.XPath("//span[contains(text(), \"Удалённые\")]"));

        public void CheckLogin()
        {
            lightPost.Click();
            Thread.Sleep(2000);

            exitLink.WaitForIsVisible();
            Assert.IsTrue(exitLink.FindElements().Count > 0);
        }

        public void WriteLetterClick()
        {
            toTypeButton.Click();
        }

        public void OpenDrafts()
        {
            drafts.Click();
        }

        public void Exit()
        {
            exitLink.Click();
        }

        public void OpenLightPost()
        {
            lightPost.Click();
        }

        public void OpenDisk()
        {
            disk.Click();
        }

        public void OpenSents()
        {
            sents.Click();
        }

        public void OpenDeleted()
        {
            trash.Click();
        }
        public void HaveDraftsFolderCheck()
        {
            Assert.IsTrue(drafts.FindElements().Count > 0);
        }
        public void HaveNotDraftsFolderCheck()
        {
            Assert.IsFalse(drafts.FindElements().Count > 0);
        }
    }
}
