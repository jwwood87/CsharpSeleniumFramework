using NUnit.Framework;
using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {

        public SampleApplicationPage(IWebDriver driver) : base(driver)
        {
        }

        public bool? IsVisible => Driver.Title.Contains(PageTitle);
        public string PageTitle => "Sample Application Lifecycle - Sprint 3 - Ultimate QA";

        string _sampleApplicationUrl = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-3";
        IWebElement _submitButton => Driver.FindElement(By.CssSelector("input[type='submit']"));
        IWebElement _firstNameInputField => Driver.FindElement(By.Name("firstname"));
        IWebElement _lastNameInputField => Driver.FindElement(By.Name("lastname"));
        IWebElement _maleRadioButton => Driver.FindElement(By.CssSelector("input[value='male']"));
        IWebElement _femaleRadioButton => Driver.FindElement(By.CssSelector("input[value='female']"));
        IWebElement _otherRadioButton => Driver.FindElement(By.CssSelector("input[value='other']"));

        internal UltimateQaHomePage FillOutFormAndSubmit(TestUser user)
        {
            _firstNameInputField.SendKeys(user.firstName);
            _lastNameInputField.SendKeys(user.lastName);
            ClickGenderButton(user);
            _submitButton.Click();
            return new UltimateQaHomePage(Driver);
        }

        private void ClickGenderButton(TestUser user)
        {
            switch (user.gender)
            {
                case Gender.Male:
                    _maleRadioButton.Click();
                    break;
                case Gender.Female:
                    _femaleRadioButton.Click();
                    break;
                case Gender.Other:
                    _otherRadioButton.Click();
                    break;
                default:
                    _otherRadioButton.Click();
                    break;
            }
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(_sampleApplicationUrl);
            Assert.IsTrue(IsVisible, $"\nExpected:\n{PageTitle} \nbut actually saw:\n{Driver.Title}");
        }
    }
}