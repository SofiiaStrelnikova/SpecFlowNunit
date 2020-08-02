using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowNunit
{
    public class YandexDiskMainPage : BasePage
    {
        private readonly string listClassName = "listing-item__fields";

        private IWebElement anyPicture => new BaseElement(By.ClassName(listClassName)).FindElements()[0];

        private IWebElement trashBox => new BaseElement(By.ClassName(listClassName)).FindElements()
                [new BaseElement(By.ClassName(listClassName)).FindElements().Count - 1];

        public void PicturesDelete()
        {    
            Utils.DragAndDropEl(anyPicture, trashBox);
            Thread.Sleep(5000);
            Utils.DoubleClick(trashBox);
            Thread.Sleep(5000);
        }
    }
}
