using OpenQA.Selenium;

namespace SpecFlowNunit
{
    public class TrashInYandexDiscPage : BasePage
    {
        private IWebElement picture => new BaseElement(By.XPath("//div[@class=\"listing-item__icon-wrapper\"]")).GetElement();
        private IWebElement restorePicture => new BaseElement(By.XPath("//span[contains(text(), \"Восстановить\")]")).GetElement();

        public void PictureRestore()
        {
            Utils.JavaScriptHighLigtEl(picture);
            Utils.JavaScriptClick(picture);
            Utils.JavaScriptClick(restorePicture);
        }
    }
}
