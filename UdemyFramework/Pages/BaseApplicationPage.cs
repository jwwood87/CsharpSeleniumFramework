using OpenQA.Selenium;
using UdemyFramework.Common;

namespace UdemyFramework
{
    public abstract class BaseApplicationPage: INavigatePage
    {
        protected IWebDriver Driver { get; set; }

        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }

        internal abstract string _PageTitle { get; }
        internal abstract string _PageUrl { get; }
        public bool? IsVisible => Driver.Title.Contains(_PageTitle);

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(_PageUrl);
        }
        //Java Script methods
        //Web Driver Wait class
        //Navigate method
        //200-lines max

    }
}