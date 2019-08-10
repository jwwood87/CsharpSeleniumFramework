using NUnit.Framework;
using System;
using OpenQA.Selenium.Chrome;
using UdemyFramework.Pages;
using UdemyFramework.Tests;

namespace UdemyFramework
{
    [TestFixture]
    public class SearchTests : BaseTest
    {
        AutomationPracticePage _searchPage;

        [SetUp]
        public void SetUpPerTest()
        {
            _searchPage = new AutomationPracticePage(Driver);
        }

        [Test]
        [Description("Test the search capability")]
        [Category("Search")]
        [Author("JohnWood")]
        public void Search_ProvideString_Success()
        {
            _searchPage.Goto();
            _searchPage.SearchStringQuery("blouse");

            Assert.AreEqual("BLOUSE", _searchPage.GetProductName());
        }

        [Test]
        public void UseEnvironmentVariable()
        {
            System.Console.WriteLine("The variable is " + Environment.GetEnvironmentVariable("John_User", EnvironmentVariableTarget.User));
        }
    }
}
