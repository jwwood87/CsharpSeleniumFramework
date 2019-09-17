using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;
using UdemyFramework.Common;

namespace UdemyFramework.Pages
{
    internal class ContactUsPage : BaseApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public bool? IsVisible => Driver.Title.Contains(PageTitle);
        public string PageTitle => "Contact Us - My Store";

        internal override string _PageTitle => throw new System.NotImplementedException();

        internal override string _PageUrl => throw new System.NotImplementedException();

        public ContactUsPage(IWebDriver driver) : base(driver)
        { }

        internal void GoTo()
        {
            _logger.Info("Navigating to the Contact Us page.");
            Reporter.LogTestStepForBugLogger(Status.Info, "Navigating to the Contact Us page.");
            Driver.Navigate().GoToUrl(Resource1.ContactUsUrl);
        }
    }
}
