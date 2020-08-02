using TechTalk.SpecFlow;

namespace SpecFlowNunit
{
	[Binding]
	public abstract class BaseTest
	{		
		protected static Browser Browser;		

		[BeforeFeature]
		public static void InitTest()
		{
			Browser = Browser.Instance;
			Browser.WindowMaximise();
			Browser.NavigateTo(Configuration.StartUrl);
		}

		[AfterFeature]
		public static void CleanTest()
		{
			Browser.Quit();
		}		
	}
}