using OpenQA.Selenium;

namespace UdemyFramework
{
    public class BaseSampleApplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseSampleApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}