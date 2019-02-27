using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyFramework.Common;

namespace UdemyFramework.Tests
{
    public class BaseTest
    {
        IWebDriver _driver;
        WebDriverFactory _webDriver;

        public IWebDriver Driver { get => _driver; set => _driver = value; }

        [SetUp]
        public void SetupBase()

        {
            _webDriver = new WebDriverFactory();
            _driver = _webDriver.CreateDriver(BrowserType.Chrome);
        }

        [TearDown]
        public void TearDownBase()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
