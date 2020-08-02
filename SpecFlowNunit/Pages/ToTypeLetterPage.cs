using OpenQA.Selenium;

namespace SpecFlowNunit
{
    public class ToTypeLetterPage : BasePage
    {
        private BaseElement toFieldInLetter => new BaseElement(By.XPath("//input[@name=\"to\"]"));
        private BaseElement themeFieldInLetter => new BaseElement(By.XPath("//input[@name=\"subj\"]"));
        private BaseElement textFieldInLetter => new BaseElement(By.XPath("//textarea[@name=\"send\"]"));
        private BaseElement saveDraftButton => new BaseElement(By.XPath("//input[@name=\"nosend\"]"));

        public void WriteDraftAndSave(string Email, string Theme, string Letter)
        {
            toFieldInLetter.SendKeys(Email);

            themeFieldInLetter.SendKeys(Theme);

            textFieldInLetter.SendKeys(Letter);

            saveDraftButton.Click();

            ForLetterConunter.GetLetterCounter(Browser.GetDriver().Url);
        }
    }
}
