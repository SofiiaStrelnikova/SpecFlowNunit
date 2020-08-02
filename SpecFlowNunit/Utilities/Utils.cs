using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace SpecFlowNunit
{
    public class Utils
    {  
        public static void JavaScriptClick(IWebElement element)
        { 
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public static void JavaScriptHighLigtEl(IWebElement element)
        {
            string bg = element.GetCssValue("backgroundColor");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", element);
            Thread.Sleep(5000);
            executor.ExecuteScript("arguments[0].style.backgroundColor = '" + bg + "'", element);
        }

        public static void DragAndDropEl(IWebElement element, IWebElement dest)
        {
            Actions actions = new Actions(Browser.GetDriver());
            actions.DragAndDrop(element, dest).Release().Build().Perform();
        }

        public static void DoubleClick(IWebElement element)
        {
            Actions actions = new Actions(Browser.GetDriver());
            actions.DoubleClick(element).Release().Build().Perform();
        }
    }
}
