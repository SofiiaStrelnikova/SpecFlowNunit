using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Drawing.Imaging;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlowNunit
{
	[Binding]
	public abstract class BaseTest
	{		
		protected static Browser Browser;		

		[BeforeScenario]
		public static void InitTest()
		{
			Browser = Browser.Instance;
			Browser.WindowMaximise();
			Browser.NavigateTo(Configuration.StartUrl);
		}

		[AfterScenario]
		public static void CleanTest()
		{
			if (TestContext.CurrentContext.Result.FailCount > 0)
			{
				ScreenshotTaker.TakeScreenshot(Path.Combine(Environment.CurrentDirectory, "Screenshots"),
					TestContext.CurrentContext.Test.Name);
			}
			Browser.Quit();
		}		
	}
}