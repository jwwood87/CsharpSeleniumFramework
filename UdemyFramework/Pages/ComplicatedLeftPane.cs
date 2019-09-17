using OpenQA.Selenium;
using AventStack.ExtentReports;
using NLog;
using UdemyFramework.Common;

namespace UdemyFramework
{
    internal class ComplicatedLeftPane : BaseApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        IWebElement _searchBox => Driver.FindElement(By.CssSelector("div[class='et_pb_column_1_4'], input[id='s']"));
        IWebElement _searchBoxSubmit => Driver.FindElement(By.CssSelector("div[class='et_pb_column_1_4'], input[id='searchsubmit']"));

        internal override string _PageTitle => throw new System.NotImplementedException();

        internal override string _PageUrl => throw new System.NotImplementedException();

        public ComplicatedLeftPane(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        internal void SearchBox()
        {
            _logger.Info("Searching with the left-side search box.");
            Reporter.LogTestStepForBugLogger(Status.Info, "Searching with the left-side search box.");
            _searchBox.Clear();
            _searchBox.SendKeys("selenium errors");
            _searchBoxSubmit.Click();
        }
    }
}