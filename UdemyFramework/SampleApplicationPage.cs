using System;
using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class SampleApplicationPage
    {
        private IWebDriver _driver;

        public SampleApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private bool? _isVisible;

        public IWebDriver Driver { get => _driver; set => _driver = value; }
        public bool? IsVisible
        {
            get
            {
                return Driver.FindElement(_SampleApplicationPage).Displayed;
            }
            set
            {
                _isVisible = value;
            }
        }
        string _ultimateQaHome = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-1";
        By _SampleApplicationPage = By.Id("submitForm");
        By _NameInputField = By.Name("firstname");

        internal UltimateQaHomePage FillOutFormAndSubmit(string input)
        {
            Driver.FindElement(_NameInputField).SendKeys(input);
            Driver.FindElement(_SampleApplicationPage).Click();
            return new UltimateQaHomePage(Driver);
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(_ultimateQaHome);

        }
    }
}