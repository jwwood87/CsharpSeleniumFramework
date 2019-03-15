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
    public class Slider : BaseApplicationPage
    {
        public Slider(IWebDriver driver) : base(driver)
        {
        }
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public string CurrentImage => _homeslider.GetAttribute("style");

        IWebElement _homeslider => Driver.FindElement(By.Id("homeslider"));
        IWebElement _NextButton => Driver.FindElement(By.ClassName("bx-next"));
        IWebElement _PreviousButton => Driver.FindElement(By.ClassName("bx-prev"));

        internal void ClickNextButton()
        {
            _logger.Info("In Slider ClickNextButton() method.");
            Reporter.LogPassingTestStepToBugLogger("In Slider class, click the next button in the slider.");
            _NextButton.Click();
        }

    }
}
