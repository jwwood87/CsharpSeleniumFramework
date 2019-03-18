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

        public AutomationPracticePage(IWebDriver driver) : base(driver)
        {
        }

        public void Goto()
        {
            _logger.Info("In browser, navigate to " + _searchUrl);
            Reporter.LogTestStepForBugLogger(Status.Info, "In the browser, navigate to {_searchUrl}.");
            Driver.Navigate().GoToUrl(_searchUrl);
            Reporter.LogPassingTestStepToBugLogger($"in a browser, go to url=>{_searchUrl}");
        }

        internal ContactUsPage ClickContactUs()
        {
            _logger.Info("In the AutomationPracticePpage, click ContactUs.");
            Reporter.LogTestStepForBugLogger(Status.Info, "In the AutomationPracticePpage, click ContactUs.");
            _contactUs.Click();

            return new ContactUsPage(Driver);  
        }

        public void SearchStringQuery(string searchString)
        {
            _logger.Info("Search for " + searchString);
            Reporter.LogTestStepForBugLogger(Status.Info, "Search for {searchString}.");
            _searchBox.SendKeys(searchString);
            _searchBoxButton.Submit();
        }

        internal SignInPage SignIn()
        {
            _logger.Info("Click the sign in link");
            Reporter.LogTestStepForBugLogger(Status.Info, "Click the Sign In link.");
            _signIn.Click();
            return new SignInPage(Driver);
        }

        public string GetProductName()
        {
            _logger.Info("Evaluate the product name.");
            Reporter.LogTestStepForBugLogger(Status.Info, "Evaluate the product name.");
            return _blouseProduct.Text.ToUpper();
        }
    }
}