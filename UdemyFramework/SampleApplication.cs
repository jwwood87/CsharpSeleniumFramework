using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyFramework
{
    [TestFixture]
    public class SampleApplication
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()

        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void FirstTest()
        {
            Console.WriteLine("This is a test");
        }

        [Test]
        public void Sample1()
        {
            var sampleApplicationPage = new SampleApplicationPage(_driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            UltimateQaHomePage ultimateQaHomePage = sampleApplicationPage.FillOutFormAndSubmit("John");
            Assert.IsTrue(ultimateQaHomePage.IsVisible);
        }
    }
}
