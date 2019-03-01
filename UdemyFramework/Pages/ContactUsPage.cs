using OpenQA.Selenium;

namespace UdemyFramework.Pages
{
    internal class ContactUsPage : BaseApplicationPage
    {

        public ContactUsPage(IWebDriver driver) : base(driver)
        { }

        public bool? IsVisible => Driver.Title.Contains(PageTitle);
        public string PageTitle => "Contact us - My Store";

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(Resource1.ContactUsUrl);
        }
    }
}
