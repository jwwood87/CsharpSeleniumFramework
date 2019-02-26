using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UdemyFramework.Pages;

namespace UdemyFramework
{
    [TestFixture]
    public class SearchFunctionality
    {
        IWebDriver _driver;
        SearchPage _searchPage;

        public IWebDriver Driver { get => _driver; set => _driver = value; }

        [SetUp]
        public void SetUpPerTest()
        {
            Driver = new ChromeDriver();
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

        [TearDown]
        public void TearDownPerTest()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
