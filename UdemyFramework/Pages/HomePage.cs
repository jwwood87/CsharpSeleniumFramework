


using NLog;
using OpenQA.Selenium;

namespace UdemyFramework.Pages
{
    public class HomePage : BaseApplicationPage
    {
        //Logger should 'live' in each page object class for functional test automation
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        public Slider Slider { get; set; }

        internal void Goto()
        {
            _logger.Info("In HomePage's Goto() method.");
            Driver.Navigate().GoToUrl(Resource1.HomePageUrl);
            _logger.Info($"Opened url=>{Resource1.HomePageUrl}");
            
        }


    }
}
