using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UdemyFramework.Common
{
    public class WebDriverFactory
    {
        public IWebDriver CreateDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }

        private IWebDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}
