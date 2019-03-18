using NLog;
using OpenQA.Selenium;

namespace UdemyFramework.Pages
{
    internal class ContactUsPage : BaseApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public bool? IsVisible => Driver.Title.Contains(PageTitle);
        public string PageTitle => "Contact us - My Store";

        public ContactUsPage(IWebDriver driver) : base(driver)
        { }

        internal void GoTo()
        {
            _logger.Info("In ContactUsPage's Goto() method.");
            Driver.Navigate().GoToUrl(Resource1.ContactUsUrl);
        }
    }
}
