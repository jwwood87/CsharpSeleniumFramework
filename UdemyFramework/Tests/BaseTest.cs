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
            Console.WriteLine("Name of the test: \t" + TestContext.CurrentContext.Test.FullName);
            _logger.Info("We're in BaseTest, starting the Setup() method.");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext.CurrentContext);
            _webDriver = new WebDriverFactory();
            _driver = _webDriver.CreateDriver(BrowserType.Chrome);
            screenshotTaker = new ScreenshotTaker(Driver, TestContext.CurrentContext);
        }

        [TearDown]
        public void TearDownBase()
        {
            _logger.Debug(GetType().FullName + " started a method tear down.");
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
                _logger.Debug(TestContext.CurrentContext.Test.Name);
                _logger.Debug("TEST STOPPED");
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
            _logger.Trace("Browser stopped successfully.");
        }
    }
}
