using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class SignInPage : BaseApplicationPage
    {
        public string PageTitle => "My Store";
        public bool? IsVisible => Driver.Title.Contains(PageTitle);

        internal override string _PageTitle => throw new System.NotImplementedException();

        internal override string _PageUrl => throw new System.NotImplementedException();

        //private IWebDriver driver;
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }
    }
}