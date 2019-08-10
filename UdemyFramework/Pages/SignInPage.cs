using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class SignInPage : BaseApplicationPage
    {
        public string PageTitle => "My Store";
        public bool? IsVisible => Driver.Title.Contains(PageTitle);
        
        //private IWebDriver driver;
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }
    }
}