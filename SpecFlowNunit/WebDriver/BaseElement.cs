using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowNunit
{
	public class BaseElement : IWebElement
	{
		private readonly By locator;
		private IWebElement element;

		public BaseElement(By locator)
		{
			this.locator = locator;
		}

		public string GetText()
		{
			this.WaitForIsVisible();
			return this.element.Text;
		}

		public IWebElement GetElement()
		{
			try
			{
				this.element = Browser.GetDriver().FindElement(this.locator);
			}
			catch (Exception)
			{
				throw;
			}
			return this.element;
		}

		public void WaitForIsVisible()
		{
			new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(ExpectedConditions.ElementIsVisible(this.locator));
		}

		public IWebElement FindElement(By @by)
		{
			return Browser.GetDriver().FindElement(@by);
		}

		public IWebElement FindElement()
		{
			return Browser.GetDriver().FindElement(this.locator);
		}

		public ReadOnlyCollection<IWebElement> FindElements(By @by)
		{
			return Browser.GetDriver().FindElements(@by);
		}

		public ReadOnlyCollection<IWebElement> FindElements()
		{
			return Browser.GetDriver().FindElements(this.locator);
		}

		public void Clear()
		{
			this.WaitForIsVisible();
			Browser.GetDriver().FindElement(this.locator).Clear();
		}

		public void SendKeys(string text)
		{
			this.WaitForIsVisible();
			Browser.GetDriver().FindElement(this.locator).SendKeys(text);
		}

		public void Submit()
		{
			this.WaitForIsVisible();
			Browser.GetDriver().FindElement(this.locator).Submit();
		}

		public void Click()
		{
			this.WaitForIsVisible();
			Browser.GetDriver().FindElement(this.locator).Click();
		}

		public string GetAttribute(string attributeName)
		{
			this.WaitForIsVisible();
			return Browser.GetDriver().FindElement(this.locator).GetAttribute(attributeName);
		}

		public string GetCssValue(string propertyName)
		{
			this.WaitForIsVisible();
			return Browser.GetDriver().FindElement(this.locator).GetCssValue(propertyName);
		}

		public string GetProperty(string propertyName)
		{
			this.WaitForIsVisible();
			return Browser.GetDriver().FindElement(this.locator).GetProperty(propertyName);
		}

		public string TagName { get; }
		public string Text { get; }
		public bool Enabled { get; }
		public bool Selected { get; }
		public Point Location { get; }
		public Size Size { get; }
		public bool Displayed { get; }
	}
}