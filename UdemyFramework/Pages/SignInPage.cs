using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class SignInPage : BaseApplicationPage
    {
        public string PageTitle => "Login - My Store";
        public bool? IsVisible => Driver.Title == PageTitle;
        
        //private IWebDriver driver;
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }
    }
}