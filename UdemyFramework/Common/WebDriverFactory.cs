using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UdemyFramework.Common
{
    public class WebDriverFactory
    {
        Logger _logger = LogManager.GetCurrentClassLogger();

        public IWebDriver CreateDriver(BrowserType browserType)
        {
            _logger.Info("In the WebDriverFactory, creating a WebDriver.");
            switch (browserType)
            {
                case BrowserType.Chrome:
                    {
                        _logger.Trace("Here's your WebDriver");
                        return GetChromeDriver();
                    }

                default:
                    {
                        _logger.Error("Error. We did not create a WebDriver.");
                        throw new ArgumentOutOfRangeException("No such browser exists");

                    }
            }
        }

        private IWebDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}
