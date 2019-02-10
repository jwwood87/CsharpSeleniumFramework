using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UdemyFramework
{
    [TestFixture]
    public class SampleApplicationTests
    {
        IWebDriver _driver;

        public IWebDriver Driver { get => _driver; set => _driver = value; }

        [SetUp]
        public void Setup()

        {
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible, "You were not on the Sample Application Home Page");

            UltimateQaHomePage ultimateQaHomePage = sampleApplicationPage.FillOutFormAndSubmit("John");
            Assert.IsTrue(ultimateQaHomePage.IsVisible, "You did not get to the Ultimate QA Page");

            Driver.Close();
            Driver.Quit();
        }
    }
}
