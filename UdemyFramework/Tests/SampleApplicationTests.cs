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
        SampleApplicationPage _sampleApplicationPage;

        public IWebDriver Driver { get => _driver; set => _driver = value; }

        [SetUp]
        public void SetupPerTest()

        {
            Driver = new ChromeDriver();
            _sampleApplicationPage = new SampleApplicationPage(Driver);
            _myUser = new TestUser();
            _myUser.firstName = "John";
            _myUser.lastName = "Wood";
            _myUser.gender = Gender.Male;
            _myUser.emergencyFirstName = "Lori";
            _myUser.emergencyLastName = "Wood";
            _myUser.EmergencyGender = Gender.Female;
        }

        [Test]
        [Author("JohnWood")]
        [Category("Search Tests")]
        [Description("This is a test description")]
        public void Test1()
        {

            _sampleApplicationPage.GoTo();
            UltimateQaHomePage ultimateQaHomePage = _sampleApplicationPage.FillOutUserFormAndSubmit(_myUser);

            Assert.IsTrue(ultimateQaHomePage.IsVisible, "You did not get to the Ultimate QA Page");
        }

        [Test]
        public void Test2()
        {
            _myUser.gender = Gender.Other;
            _sampleApplicationPage.GoTo();
            UltimateQaHomePage ultimateQaHomePage = _sampleApplicationPage.FillOutUserFormAndSubmit(_myUser);

            Assert.IsTrue(ultimateQaHomePage.IsVisible, "You did not get to the Ultimate QA Page");
        }

        [Test]
        public void Test3()
        {
            _sampleApplicationPage.GoTo();
            UltimateQaHomePage ultimateQaHomePage = _sampleApplicationPage.FillOutUserFormAndSubmit(_myUser);
            Driver.Navigate().Back();
            _sampleApplicationPage.FillOutEmergencyContactFormAndSubmit(_myUser);

            Assert.IsTrue(ultimateQaHomePage.IsVisible, "You did not get to the Ultimate QA Page");
        }

        [Test]
        public void Test4()
        {
            TestUser testUser = new TestUser();
            testUser = Utilities.GetDataFromJsonFile<TestUser>("User1.json");
        }
        [TearDown]
        public void TearDownPerTest()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
