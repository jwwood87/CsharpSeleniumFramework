using System;
using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class UltimateQaHomePage : BaseSampleApplicationPage
    {
        public UltimateQaHomePage(IWebDriver driver) :base(driver)
        {
        }

        //public bool? IsVisible
        //{
        //    get => Driver.Title == "Home - Ultimate QA";
        //    set => IsVisible = value;
        //}

        public bool? IsVisible => Driver.Title == "Home - Ultimate QA";
    }
}
