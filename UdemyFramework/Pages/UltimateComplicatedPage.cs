using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UdemyFramework.Common;

namespace UdemyFramework
{
    internal class UltimateComplicatedPage : BaseApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public bool? IsVisible => Driver.Title == "Complicated Page - Ultimate QA";
        // Convert a section of this large page into a separate class with its own methods and IWebElements
        public ComplicatedLeftPane ComplicatedLeftPane { get; set; }

        IWebElement _nameField => Driver.FindElement(By.Id("et_pb_contact_name_0"));
        IWebElement _emailField => Driver.FindElement(By.Id("et_pb_contact_email_0"));
        IWebElement _messageField => Driver.FindElement(By.Id("et_pb_contact_message_0"));
        IWebElement _captchaQuestion => Driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
        IWebElement _captchaAnswer => Driver.FindElement(By.ClassName("et_pb_contact_captcha"));
        IWebElement _submitButton => Driver.FindElement(By.ClassName("et_pb_contact_submit"));
        IWebElement _thanksContactingMessage => Driver.FindElement(By.ClassName("et-pb-contact-message"));

        public UltimateComplicatedPage(IWebDriver driver) : base(driver)
        {
            ComplicatedLeftPane = new ComplicatedLeftPane(driver);
        }

        internal void Goto()
        {
            _logger.Info("Log file: Go to the page, " + Resource1.UltimateComplicatedUrl);
            Reporter.LogTestStepForBugLogger(Status.Info, "Extent Report: Go to the page, " + Resource1.UltimateComplicatedUrl);
            Driver.Navigate().GoToUrl(Resource1.UltimateComplicatedUrl);
        }

        internal void FillOutForm()
        {
            _logger.Info("Fill out the form at {Resource1.UltimateComplicatedUrl}");
            Reporter.LogTestStepForBugLogger(Status.Info, "Fill out the form at {Resource1.UltimateComplicatedUrl}");
            _nameField.Clear();
            _nameField.SendKeys("John Wood");
            _emailField.Clear();
            _emailField.SendKeys("johnWesWood@protonMail.com");
            _messageField.Clear();
            _messageField.SendKeys("The rain in Spain...");
        }

        internal void SubmitForm()
        {
            _logger.Info("Answer the Captcha problem and submit the form.");
            Reporter.LogTestStepForBugLogger(Status.Info, "Answer the Captcha problem and submit the form.");
            AnswerCaptchaProblem();
            _submitButton.Click();
        }

        internal bool SignInSuccessful()
        {
            _logger.Info("Determining whether the sign-in was successful.");
            Reporter.LogTestStepForBugLogger(Status.Info, "Determining whether the sign-in was successful.");
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 3));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("et-pb-contact-message")));
            return _thanksContactingMessage.Displayed;
        }

        private void AnswerCaptchaProblem()
        {
            _logger.Info("Answering the Captcha problem.");
            Reporter.LogPassingTestStepToBugLogger("Answering the Captcha problem.");
            string[] theNumbers = _captchaQuestion.Text.Split(' ');
            int theAnswer = int.Parse(theNumbers[0]) + int.Parse(theNumbers[2]);
            _captchaAnswer.Clear();
            _captchaAnswer.SendKeys(theAnswer.ToString());
        }
    }
}