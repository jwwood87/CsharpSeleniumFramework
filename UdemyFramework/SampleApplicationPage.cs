using System;
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
        public string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";

        string _sampleApplicationUrl = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-4";
        IWebElement _submitButton => Driver.FindElement(By.CssSelector("input[type='submit']"));
        IWebElement _firstName => Driver.FindElement(By.Name("firstname"));
        IWebElement _lastName => Driver.FindElement(By.Name("lastname"));
        IWebElement _maleRadio => Driver.FindElement(By.CssSelector("input[value='male']"));
        IWebElement _femaleRadio => Driver.FindElement(By.CssSelector("input[value='female']"));
        IWebElement _otherRadio => Driver.FindElement(By.CssSelector("input[value='other']"));
        IWebElement _emergencySubmitButton => Driver.FindElement(By.Id("submit2"));
        IWebElement _emergencyFirstName => Driver.FindElement(By.Id("f2"));
        IWebElement _emergencyLastName => Driver.FindElement(By.Id("l2"));
        IWebElement _emergencyMaleRadio => Driver.FindElement(By.Id("radio2-m"));
        IWebElement _emergencyFemaleRadio => Driver.FindElement(By.Id("radio2-f"));
        IWebElement _emergencyOtherRadio => Driver.FindElement(By.Id("radio2-0"));

        internal UltimateQaHomePage FillOutUserFormAndSubmit(TestUser user)
        {
            _firstName.SendKeys(user.firstName);
            _lastName.SendKeys(user.lastName);
            ClickGenderButton(user);
            _submitButton.Click();
            return new UltimateQaHomePage(Driver);
        }

        
        internal UltimateQaHomePage FillOutEmergencyContactFormAndSubmit(TestUser myUser)
        {
            _emergencyFirstName.SendKeys(myUser.emergencyFirstName);
            _emergencyLastName.SendKeys(myUser.emergencyLastName);
            ClickEmergencyGender(myUser);
            _emergencySubmitButton.Click();
            return new UltimateQaHomePage(Driver);
        }

        private void ClickEmergencyGender(TestUser myUser)
        {
            switch (myUser.gender)
            {
                case Gender.Male:
                    _emergencyMaleRadio.Click();
                    break;
                case Gender.Female:
                    _emergencyFemaleRadio.Click();
                    break;
                case Gender.Other:
                    _emergencyOtherRadio.Click();
                    break;
                default:
                    _emergencyOtherRadio.Click();
                    break;
            }
        }

        private void ClickGenderButton(TestUser user)
        {
            switch (user.gender)
            {
                case Gender.Male:
                    _maleRadio.Click();
                    break;
                case Gender.Female:
                    _femaleRadio.Click();
                    break;
                case Gender.Other:
                    _otherRadio.Click();
                    break;
                default:
                    _otherRadio.Click();
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