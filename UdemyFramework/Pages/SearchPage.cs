using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;
using UdemyFramework.Common;

namespace UdemyFramework.Pages
{
    public class SearchPage : BaseApplicationPage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        string _searchUrl = "http://www.automationpractice.com";
        IWebElement _searchBox => Driver.FindElement(By.Id("search_query_top"));
        IWebElement _searchBoxButton => Driver.FindElement(By.Name("submit_search"));
        IWebElement _blouseProduct => Driver.FindElement(By.LinkText("Blouse"));

        public void Goto()
        {
            _logger.Info("In SearchPage's Goto() method.");
            Driver.Navigate().GoToUrl(_searchUrl);
            Reporter.LogPassingTestStepToBugLogger($"in a browser, go to url=>{_searchUrl}");
        }

        public void SearchStringQuery(string searchString)
        {
            _logger.Info("Staring Info logging for SearchStringQuery()");
            _searchBox.SendKeys(searchString);
            _searchBoxButton.Submit();
        }

        public string GetProductName()
        {
            return _blouseProduct.Text.ToUpper();
        }

        public bool Contains(string searchReturn)
        {
            return true;
        }
    }
}