using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using UdemyFramework.Common;
using UdemyFramework.Pages;
using UdemyFramework.Tests;

namespace UdemyFramework
{

    public class ContactUs : BaseTest
    {
        [Test]
        [Author("JohnWood")]
        [Category("ContactUs Test")]
        [Description("This test checks that the Contact Us page loads.")]
        public void ContactUs1()
        {
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();

            Assert.IsTrue(contactUsPage.PageTitle.Contains("Contact"), "The expected page did not appear.");
        }
    }
}
