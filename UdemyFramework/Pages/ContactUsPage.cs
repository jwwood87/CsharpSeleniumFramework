using NLog;
using OpenQA.Selenium;

namespace UdemyFramework.Pages
{
    internal class ContactUsPage : BaseApplicationPage
    {

        public ContactUsPage(IWebDriver driver) : base(driver)
        { }

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public bool? IsVisible => Driver.Title.Contains(PageTitle);
        public string PageTitle => "Contact us - My Store";

        internal void GoTo()
        {
            _logger.Info("In ContactUsPage's Goto() method.");
            Driver.Navigate().GoToUrl(Resource1.ContactUsUrl);
        }
    }
}
