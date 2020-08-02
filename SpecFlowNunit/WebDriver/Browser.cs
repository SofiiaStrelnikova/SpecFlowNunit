using System;
using OpenQA.Selenium;

namespace SpecFlowNunit
{
	public class Browser
	{
		private static Browser currentInstane;
		private static IWebDriver driver;
		private static BrowserFactory.BrowserType currentBrowser;
		private static int implWait;
		private static double timeoutForElement;
		private static string browser;

		private Browser()
		{
			InitParamas();
			driver = BrowserFactory.GetDriver(currentBrowser, implWait);
		}

		private static void InitParamas()
		{
			implWait = Convert.ToInt32(Configuration.ElementTimeout);
			timeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
			browser = Configuration.Browser;
			Enum.TryParse(browser, out currentBrowser);
		}

		public static Browser Instance => currentInstane ?? (currentInstane = new Browser());

		public static double TimeoutForElement
		{
			get
			{
				return timeoutForElement;
			}
			private set { }
		}

		public static void WindowMaximise()
		{
			driver.Manage().Window.Maximize();
		}

		public static void NavigateTo(string url)
		{
			driver.Navigate().GoToUrl(url);
		}

		public static IWebDriver GetDriver()
		{
			return driver;
		}

		public static void Quit()
		{
			driver.Quit();
			currentInstane = null;
			driver = null;
			browser = null;
		}
	}
}