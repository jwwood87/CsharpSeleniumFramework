using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using UdemyFramework.Common;

namespace UdemyFramework.Tests
{
    [TestFixture]
    public class BaseTest
    {
        IWebDriver _driver;
        WebDriverFactory _webDriver;
        private ScreenshotTaker screenshotTaker { get; set; }
        public IWebDriver Driver { get => _driver; set => _driver = value; }
        private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void SetupBase()

        {
            _logger.Debug("Log file: We're in BaseTest, Setup(), test name: " + TestContext.CurrentContext.Test.Name);
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext.CurrentContext);
            _webDriver = new WebDriverFactory();
            _driver = _webDriver.CreateDriver(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            screenshotTaker = new ScreenshotTaker(Driver, TestContext.CurrentContext);
        }

        [TearDown]
        public void TearDownBase()
        {
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                _logger.Error(e.Source);
                _logger.Error(e.StackTrace);
                _logger.Error(e.InnerException);
                _logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                //_logger.Trace(TestContext.CurrentContext.Test.Name);
                _logger.Trace("Test stopped\n");
                Reporter.LogTestStepForBugLogger(Status.Info, "Test stopped.\n");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (screenshotTaker != null)
            {
                screenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(screenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            _logger.Debug("Log file: Browser stopped successfully.");
        }

    }
}
