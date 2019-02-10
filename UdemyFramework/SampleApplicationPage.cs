using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {

        public SampleApplicationPage(IWebDriver driver) : base(driver)
        {
        }

        public bool? IsVisible => Driver.Title.Contains("Sample Application Lifecycle");
 
        string _sampleApplicationUrl = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-1";
        IWebElement _firstNameSubmitButton => Driver.FindElement(By.Id("submitForm"));
        IWebElement _nameInputField => Driver.FindElement(By.Name("firstname"));

        internal UltimateQaHomePage FillOutFormAndSubmit(string fName)
        {
            _nameInputField.SendKeys(fName);
            _firstNameSubmitButton.Click();
            return new UltimateQaHomePage(Driver);
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(_sampleApplicationUrl);
        }
    }
}