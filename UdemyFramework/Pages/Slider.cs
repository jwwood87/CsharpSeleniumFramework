using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UdemyFramework.Pages
{
    public class Slider : BaseApplicationPage
    {
        public Slider(IWebDriver driver) : base(driver)
        {
        }

        public string CurrentImage => _homeslider.GetAttribute("style");

        IWebElement _homeslider => Driver.FindElement(By.Id("homeslider"));
        IWebElement _NextButton => Driver.FindElement(By.ClassName("bx-next"));
        IWebElement _PreviousButton => Driver.FindElement(By.ClassName("bx-prev"));

        internal void ClickNextButton()
        {
            _NextButton.Click();
        }

    }
}
