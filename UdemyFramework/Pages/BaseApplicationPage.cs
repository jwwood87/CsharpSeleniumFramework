using OpenQA.Selenium;

namespace UdemyFramework
{
    public class BaseApplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}