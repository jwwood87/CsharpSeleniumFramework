﻿


using NLog;
using OpenQA.Selenium;

namespace UdemyFramework.Pages
{
    public class HomePage : BaseApplicationPage
    {
        //Logger should 'live' in each page object class for functional test automation
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public Slider Slider { get; set; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        internal void Goto()
        {
            _logger.Info("Log file: In a browser, navigate to " + Resource1.AutomationPracticeUrl);
            Driver.Navigate().GoToUrl(Resource1.AutomationPracticeUrl);
        }
    }
}
