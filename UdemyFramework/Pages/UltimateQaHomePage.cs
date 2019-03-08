using System;
using OpenQA.Selenium;

namespace UdemyFramework
{
    internal class UltimateQaHomePage : BaseApplicationPage
    {
        public UltimateQaHomePage(IWebDriver driver) :base(driver)
        {
        }

        // The old way of doing a property
        //public bool? IsVisible
        //{
        //    get => Driver.Title == "Home - Ultimate QA";
        //    set => IsVisible = value;
        //}

        public bool? IsVisible => Driver.Title == "Home - Ultimate QA";
    }
}
