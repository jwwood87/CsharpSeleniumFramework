


using OpenQA.Selenium;

namespace UdemyFramework.Pages
{
    public class HomePage : BaseApplicationPage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        public Slider Slider { get; set; }

        internal void Goto()
        {
            Driver.Navigate().GoToUrl(Resource1.HomePageUrl);
        }


    }
}
