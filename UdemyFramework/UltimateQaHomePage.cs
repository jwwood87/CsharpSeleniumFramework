using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class UltimateQaHomePage
    {
        IWebDriver _driver;

        public UltimateQaHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public bool? IsVisible
        {
            get
            {
                return Driver.Title == "Home - Ultimate QA";
            }
            set
            {
                IsVisible = value;
            }
        }
        
        public IWebDriver Driver { get => _driver; set => _driver = value; }

    }
}