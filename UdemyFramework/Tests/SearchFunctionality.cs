using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UdemyFramework.Pages;
using UdemyFramework.Tests;

namespace UdemyFramework
{
    [TestFixture]
    public class SearchFunctionality : BaseTest
    {
        SearchPage _searchPage;

        [SetUp]
        public void SetUpPerTest()
        {
            _searchPage = new SearchPage(Driver);
        }

        [Test]
        [Description("Test the search capability")]
        [Category("Search")]
        [Author("JohnWood")]
        public void TestMethod1()
        {
            _searchPage.Goto();
            _searchPage.SearchStringQuery("blouse");

            Assert.AreEqual("BLOUSE", _searchPage.GetProductName());
        }

        [Test]
        [Description("Send a Customer Service- Contact Us Message")]
        [Category("CustomerService")]
        [Author("JohnWood")]
        public void Quiz1()
        {
            //Goto automationpractice.com/index.php?controller=contact
            //Page is loaded
            //We are able to contact an individual
        }
    }
}
