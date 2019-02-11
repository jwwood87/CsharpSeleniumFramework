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
        TestUser _myUser;

        public IWebDriver Driver { get => _driver; set => _driver = value; }

        [SetUp]
        public void SetupPerTest()

        {
            Driver = new ChromeDriver();
            _myUser = new TestUser();
            _myUser.firstName = "John";
            _myUser.lastName = "Wood";
            _myUser.gender = Gender.Male;
        }

        [Test]
        public void Test1()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            UltimateQaHomePage ultimateQaHomePage = sampleApplicationPage.FillOutFormAndSubmit(_myUser);

            Assert.IsTrue(ultimateQaHomePage.IsVisible, "You did not get to the Ultimate QA Page");
        }

        [Test]
        public void Test2()
        {
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            UltimateQaHomePage ultimateQaHomePage = sampleApplicationPage.FillOutFormAndSubmit(_myUser);

            Assert.IsTrue(ultimateQaHomePage.IsVisible, "You did not get to the Ultimate QA Page");
        }

        [Test]
        public void Test3()
        {
            _myUser.gender = Gender.Other;
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            sampleApplicationPage.GoTo();
            UltimateQaHomePage ultimateQaHomePage = sampleApplicationPage.FillOutFormAndSubmit(_myUser);

            Assert.IsTrue(ultimateQaHomePage.IsVisible, "You did not get to the Ultimate QA Page");
        }

        [TearDown]
        public void TearDownPerTest()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
