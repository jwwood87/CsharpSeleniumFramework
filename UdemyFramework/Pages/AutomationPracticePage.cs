using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;
using UdemyFramework.Common;

namespace UdemyFramework.Pages
{
    public class AutomationPracticePage : BaseApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public bool? IsVisible { get; internal set; }
        string _searchUrl = Resource1.AutomationPracticeUrl;
        IWebElement _searchBox => Driver.FindElement(By.Id("search_query_top"));
        IWebElement _searchBoxButton => Driver.FindElement(By.Name("submit_search"));
        IWebElement _blouseProduct => Driver.FindElement(By.LinkText("Blouse"));
        IWebElement _contactUs => Driver.FindElement(By.Id("contact-link"));
        IWebElement _signIn => Driver.FindElement(By.ClassName("login"));

        internal override string _PageTitle => throw new System.NotImplementedException();

        internal override string _PageUrl => throw new System.NotImplementedException();

        public AutomationPracticePage(IWebDriver driver) : base(driver)
        {
        }

        public void Goto()
        {
            _logger.Info("Navigating to " + _searchUrl);
            Reporter.LogTestStepForBugLogger(Status.Info, $"Navigating to {_searchUrl}.");
            Driver.Navigate().GoToUrl(_searchUrl);
        }

        internal ContactUsPage ClickContactUs()
        {
            _logger.Info("In the AutomationPracticePpage, clicking the ContactUs link.");
            Reporter.LogTestStepForBugLogger(Status.Info, "In the AutomationPracticePpage, clicking the ContactUs link.");
            _contactUs.Click();

            return new ContactUsPage(Driver);  
        }

        public void SearchStringQuery(string searchString)
        {
            _logger.Info("Searching for " + searchString);
            Reporter.LogTestStepForBugLogger(Status.Info, "Searching for {searchString}.");
            _searchBox.SendKeys(searchString);
            _searchBoxButton.Submit();
        }

        internal SignInPage SignIn()
        {
            _logger.Info("Clicking the Sign-in link");
            Reporter.LogTestStepForBugLogger(Status.Info, "Clicking the SigniIn link.");
            _signIn.Click();
            return new SignInPage(Driver);
        }

        public string GetProductName()
        {
            _logger.Info("Log file: Evaluate the product name.");
            Reporter.LogTestStepForBugLogger(Status.Info, "Extent Report: Evaluate the product name.");
            return _blouseProduct.Text.ToUpper();
        }
    }
}