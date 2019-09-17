


using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;
using UdemyFramework.Common;

namespace UdemyFramework.Pages
{
    public class HomePage : BaseApplicationPage
    {
        //Logger should 'live' in each page object class for functional test automation
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public Slider Slider { get; set; }

        internal override string _PageTitle => throw new System.NotImplementedException();

        internal override string _PageUrl => throw new System.NotImplementedException();

        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        internal void Goto()
        {
            _logger.Info("In a browser, navigate to " + Resource1.AutomationPracticeUrl);
            Reporter.LogTestStepForBugLogger(Status.Info, "In a browser, navigate to " + Resource1.AutomationPracticeUrl);
            Driver.Navigate().GoToUrl(Resource1.AutomationPracticeUrl);
        }
    }
}
